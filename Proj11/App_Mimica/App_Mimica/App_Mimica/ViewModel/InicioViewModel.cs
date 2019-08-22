using App_Mimica.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Xamarin.Forms;

namespace App_Mimica.ViewModel
{
    public class InicioViewModel : INotifyPropertyChanged
    {
        public string MsgErro
        {
            get
            {
                return _msgErro;
            }
            set
            {
                _msgErro = value;
                OnPropertyChanged("MsgErro");
            }
        }
        private string _msgErro;
        public JogoModel Jogo { get; set; }
        public Command IniciarCommand { get; set; }
        public InicioViewModel()
        {
            IniciarCommand = new Command(IniciarJogo);
            Jogo = new JogoModel();
            Jogo.Grupo1 = new GrupoModel();
            Jogo.Grupo2 = new GrupoModel();

            Jogo.Tempo = 60; //segundos
            Jogo.Rodadas = 3;

        }

        private void IniciarJogo()
        {
            string erro = "";
            if (Jogo.Tempo < 10)
                erro += "Tempo mínimo da palavra é de 10 segundos";

            if (Jogo.Rodadas <= 0)
                erro += "\nÉ preciso ter no mínimo 1 rodada para iniciar o jogo";

            if(erro.Length > 0)
            {
                MsgErro = erro;
            }
            else
            {
                Armazenamento.Armazenamento.Jogo = this.Jogo;
                Armazenamento.Armazenamento.RodadaAtual = 1;

                App.Current.MainPage = new View.Jogo(Jogo.Grupo1);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string NameProperty)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(NameProperty));
            }
        }
    }
}
