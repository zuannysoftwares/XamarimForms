using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using ZYChat.Model;
using ZYChat.Service;

namespace ZYChat.ViewModel
{
    public class CadastrarChatViewModel : INotifyPropertyChanged
    {
        public string nome { get; set; }
        private string _mensagem { get; set; }
        public string mensagem {
            get { return _mensagem; }
            set { _mensagem = value; OnPropertyChanged("mensagem"); }
        }
        public Command CadastrarCommand { get; set; }

        public CadastrarChatViewModel()
        {
            CadastrarCommand = new Command(Cadastrar);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
        }

        private void Cadastrar()
        {
            var chat = new Chat() { nome = nome };
            bool ok = ServiceWS.InsertChat(chat);

            var Nav = ((NavigationPage)App.Current.MainPage);
            var Chats = (View.Chats)Nav.RootPage;
            var ViewModel = (ChatsViewModel)Chats.BindingContext;

            if (ok)
            {
                ((NavigationPage)App.Current.MainPage).Navigation.PopAsync();

                if (ViewModel.AtualizarCommand.CanExecute(null))
                {
                    ViewModel.AtualizarCommand.Execute(null);
                }
            }
            else
            {
                mensagem = "Ocorreu um erro no cadasro.";
            }

        }
    }
}
