using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZYChat.Model;
using ZYChat.Service;

namespace ZYChat.ViewModel
{
    public class CadastrarChatViewModel : INotifyPropertyChanged
    {
        private bool _carregando;
        public bool Carregando { get { return _carregando; } set { _carregando = value; OnPropertyChanged("Carregando"); } }
        public string nome { get; set; }
        private string _mensagem { get; set; }
        public string mensagem {
            get { return _mensagem; }
            set { _mensagem = value; OnPropertyChanged("mensagem"); }
        }

        private bool _mensagemErro;
        public bool MensagemErro { get { return _mensagemErro; } set { _mensagemErro = value; OnPropertyChanged("MensagemErro"); } }

        public Command CadastrarCommand { get; set; }

        public CadastrarChatViewModel()
        {
            CadastrarCommand = new Command(CadastrarButton);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
        }

        private void CadastrarButton()
        {
            bool result = Task.Run(() => Cadastrar()).GetAwaiter().GetResult();

            if(result)
            {
                var PaginaAtual = ((NavigationPage)App.Current.MainPage);
                PaginaAtual.PopAsync();
            }
        }

        private async Task<bool> Cadastrar()
        {
            Carregando = true;

            try
            {
                MensagemErro = false;

                var chat = new Chat() { nome = nome };
                bool ok = await ServiceWS.InsertChat(chat);

                if (ok)
                {
                    var PagAtual = ((NavigationPage)App.Current.MainPage);
                    var Chats = (View.Chats)PagAtual.RootPage;
                    var ViewModel = (ChatsViewModel)Chats.BindingContext;

                    if (ViewModel.AtualizarCommand.CanExecute(null))
                    {
                        ViewModel.AtualizarCommand.Execute(null);
                    }

                    return true;
                }
                else
                {
                    mensagem = "Ocorreu um erro no cadasro.";
                    Carregando = false;
                    return false;
                }
            }
            catch (Exception e )
            {
                MensagemErro = true;
                mensagem = e.Message;
                Carregando = false;
                return false;
            }
        }
    }
}
