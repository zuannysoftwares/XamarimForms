using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using ZYChat.Model;
using ZYChat.Service;
using System.Linq;
using System.Threading.Tasks;

namespace ZYChat.ViewModel
{
    public class ChatsViewModel : INotifyPropertyChanged
    {
        private List<Chat> _chats;

        public List<Chat> Chats { get { return _chats; } set { _chats = value; OnPropertyChanged("Chats"); } }

        private Chat _selectedItemChat;

        private bool _carregando;
        public bool Carregando { get { return _carregando; } set { _carregando = value; OnPropertyChanged("Carregando"); } }
        public Chat SelectedItemChat { get { return _selectedItemChat; } set { _selectedItemChat = value; OnPropertyChanged("SelectedItemChat"); GoPaginaMensagem(value); } }

        public Command AdicionarCommand { get; set; }
        public Command OrdenarCommand { get; set; }
        public Command AtualizarCommand { get; set; }


        public ChatsViewModel()
        {
            Task.Run(() => CarregarChats());

            AdicionarCommand = new Command(Adicionar);
            OrdenarCommand = new Command(Ordenar);
            AtualizarCommand = new Command(Atualizar);
        }
        private async Task CarregarChats()
        {
            Carregando = true;
            Chats = await ServiceWS.GetChats();
            Carregando = false;
        }

        private void Adicionar()
        {
            ((NavigationPage)App.Current.MainPage).Navigation.PushAsync(new View.CadastrarChat());
        }

        private void Ordenar()
        {
            Chats = Chats.OrderBy(c => c.nome).ToList();
        }

        private void Atualizar()
        {
            Task.Run(() => CarregarChats());
        }

        private void GoPaginaMensagem(Chat chat)
        {
            if (chat != null)
            {
                SelectedItemChat = null;

                ((NavigationPage)App.Current.MainPage).Navigation.PushAsync(new View.Mensagem(chat));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string PropertyName)
        {
            if (PropertyName != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
        }


    }
}
