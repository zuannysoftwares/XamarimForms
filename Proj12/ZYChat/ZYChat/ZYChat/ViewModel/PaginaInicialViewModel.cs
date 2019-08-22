using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using ZYChat.Model;
using ZYChat.Service;
using Newtonsoft.Json;
using System.Threading.Tasks;
using ZYChat.Util;

namespace ZYChat.ViewModel
{
    public class PaginaInicialViewModel : INotifyPropertyChanged
    {
        private string _nome;
        private string _senha;
        private string _mensagem;
        private bool _carregando;
        private bool _mensagemErro;
        public string Nome { get { return _nome; } set { _nome = value; OnPropertyChanged("Nome"); } }
        public string Senha { get { return _senha; } set { _senha = value; OnPropertyChanged("Senha"); } }
        public string Mensagem { get { return _mensagem; } set { _mensagem = value; OnPropertyChanged("Mensagem"); } }
        public bool MensagemErro { get { return _mensagemErro; } set { _mensagemErro = value; OnPropertyChanged("MensagemErro"); } }
        public bool Carregando{ get { return _carregando; } set{ _carregando = value; OnPropertyChanged("Carregando");} }

        public Command AcessarCommand { get; set; }

        public PaginaInicialViewModel()
        {
            AcessarCommand = new Command(Acessar);
        }

        private async void Acessar()
        {
            try
            {
                MensagemErro = false;
                Carregando = true;
                var user = new Usuario();
                user.nome = Nome;
                user.password = Senha;

                var usuarioLogado = await ServiceWS.GetUsuario(user);
                if (usuarioLogado == null)
                {
                    Mensagem = "Senha incorreta.";
                    Carregando = false;
                }
                else
                {
                    UsuarioUtil.SetUsuarioLogado(usuarioLogado);
                    App.Current.MainPage = new NavigationPage(new View.Chats())
                    {
                        BarBackgroundColor = Color.FromHex("#5ED055"),
                        BarTextColor = Color.White
                    };
                }
            }
            catch (Exception e)
            {
                MensagemErro = true;
            }
            finally
            {
                Carregando = false;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
        }
    }
}
