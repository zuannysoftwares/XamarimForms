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
        private StackLayout SL;
        private Chat chat;
        private List<Mensagem> _mensagens;

        public List<Mensagem> Mensagens { get { return _mensagens; } set { _mensagens = value; OnPropertyChanged("Mensagens"); if (_mensagens != null) { ShowOnScreen(); } } }

        private string _txtMensagem;

        public string TxtMensagem { get { return _txtMensagem; } set { _txtMensagem = value; OnPropertyChanged("TxtMensagem"); } }

        public Command btnEnviarCommand { get; set; }
        public Command AtualizarCommand { get; set; }


        public MensagemViewModel(Chat chat, StackLayout SLMenagemContainer)
        {
            this.chat = chat;
            SL = SLMenagemContainer;
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

        private void ShowOnScreen()
        {
            var usuario = Util.UsuarioUtil.GetUsuarioLogado();
            SL.Children.Clear();

            foreach (var msg in Mensagens)
            {
                if (msg.usuario.id == usuario.id)
                {
                    SL.Children.Add(CriarMensagemPropria(msg));
                }
                else
                {
                    SL.Children.Add(CriarMensagemOutrosUsuarios(msg));
                }
            }
        }

        private Xamarin.Forms.View CriarMensagemPropria(Mensagem mesg)
        {
            var layout = new StackLayout() { Padding = 5, BackgroundColor = Color.FromHex("#5ED055"), HorizontalOptions = LayoutOptions.End };
            var label = new Label() { TextColor = Color.White, Text = mesg.mensagem };

            layout.Children.Add(label);
            return layout;
        }

        private Xamarin.Forms.View CriarMensagemOutrosUsuarios(Mensagem msg)
        {
            var labelNome = new Label() { Text = msg.usuario.nome, FontSize = 10, TextColor = Color.FromHex("#5ED055") };
            var labelMensagem = new Label() { Text = msg.mensagem, TextColor = Color.FromHex("#5ED055") };

            var SL = new StackLayout();
            SL.Children.Add(labelNome);
            SL.Children.Add(labelMensagem);

            var frame = new Frame() { BorderColor = Color.FromHex("#5ED055"), CornerRadius = 0, HorizontalOptions = LayoutOptions.Start };
            frame.Content = SL;

            return frame;
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
