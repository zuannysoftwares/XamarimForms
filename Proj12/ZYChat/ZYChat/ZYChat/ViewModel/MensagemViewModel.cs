using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using ZYChat.Model;
using ZYChat.Service;
using System.Linq;
using ZYChat.Util;


namespace ZYChat.ViewModel
{
    public class MensagemViewModel : INotifyPropertyChanged
    {
        //private StackLayout SL;
        private Chat chat;
        private List<Mensagem> _mensagens;

        public List<Mensagem> Mensagens
        {
            get
            {
                return _mensagens;
            }
            set
            {
                _mensagens = value;
                OnPropertyChanged("Mensagens");
            }
        }

        private string _txtMensagem;

        public string TxtMensagem { get { return _txtMensagem; } set { _txtMensagem = value; OnPropertyChanged("TxtMensagem"); } }

        public Command btnEnviarCommand { get; set; }
        public Command AtualizarCommand { get; set; }


        public MensagemViewModel(Chat chat)
        {
            this.chat = chat;
            Mensagens = ServiceWS.GetMensagensChat(chat);

            Atualizar();

            btnEnviarCommand = new Command(BtnEnviar);
            AtualizarCommand = new Command(Atualizar);

            Device.StartTimer(TimeSpan.FromSeconds(1), () => { Atualizar(); return true; });
        }

        private void Atualizar()
        {
            Mensagens = ServiceWS.GetMensagensChat(chat);
        }

        private void BtnEnviar()
        {
            var msg = new Mensagem()
            {
                id_usuario = UsuarioUtil.GetUsuarioLogado().id,
                mensagem = TxtMensagem,
                id_chat = chat.id
            };

            ServiceWS.InsertMensagem(msg);
            Atualizar();

            TxtMensagem = string.Empty;
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
