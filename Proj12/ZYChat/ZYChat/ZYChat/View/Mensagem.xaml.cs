using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZYChat.Model;

namespace ZYChat.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Mensagem : ContentPage
	{
		public Mensagem (Chat chat)
		{
			InitializeComponent ();

            BindingContext = new ViewModel.MensagemViewModel(chat, SLMenagemContainer);
		}
	}
}