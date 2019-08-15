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
        public JogoModel Jogo { get; set; }
        public Command IniciarCommand { get; set; }
        public InicioViewModel()
        {
            IniciarCommand = new Command(IniciarJogo);
            Jogo = new JogoModel();
            Jogo.Grupo1 = new GrupoModel();
            Jogo.Grupo2 = new GrupoModel();
        }

        private void IniciarJogo()
        {
            Armazenamento.Armazenamento.Jogo = this.Jogo;
            Armazenamento.Armazenamento.RodadaAtual = 1;

            App.Current.MainPage = new View.Jogo(Jogo.Grupo1);
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
