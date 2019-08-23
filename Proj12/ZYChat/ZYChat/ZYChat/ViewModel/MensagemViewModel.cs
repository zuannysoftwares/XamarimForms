using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using ZYChat.Model;
using ZYChat.Service;
using System.Linq;
using ZYChat.Util;
using System.Threading.Tasks;

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

        private bool _mensagemErro;
        public bool MensagemErro { get { return _mensagemErro; } set { _mensagemErro = value; OnPropertyChanged("MensagemErro"); } }

        private string _txtMensagem;
        private bool _carregando;
        public string TxtMensagem { get { return _txtMensagem; } set { _txtMensagem = value; OnPropertyChanged("TxtMensagem"); } }
        public bool Carregando { get { return _carregando; } set { _carregando = value; OnPropertyChanged("Carregando"); } }
        public Command btnEnviarCommand { get; set; }
        public Command AtualizarCommand { get; set; }


        public MensagemViewModel(Chat chat)
        {
            this.chat = chat;
            //Mensagens = await ServiceWS.GetMensagensChat(chat);

            Task.Run(() => Atualizar());

            btnEnviarCommand = new Command(BtnEnviar);
            AtualizarCommand = new Command(AtualizarNoAsync);

            Device.StartTimer(TimeSpan.FromSeconds(1), () => {
                Task.Run(() => AtualizarSemRecarregarTela());
                return true;
            });
        }

        private async Task Atualizar()
        {
            try
            {
                MensagemErro = false;
                Carregando = true;
                Mensagens = await ServiceWS.GetMensagensChat(chat);
                Carregando = false;
            }
            catch (Exception e)
            {
                Carregando = false;
                MensagemErro = true;
            }
        }

        private async Task AtualizarSemRecarregarTela()
        {
            Mensagens = await ServiceWS.GetMensagensChat(chat);
        }

        private void AtualizarNoAsync()
        {
            Task.Run(() => Atualizar());
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
            Task.Run(() => Atualizar());

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
