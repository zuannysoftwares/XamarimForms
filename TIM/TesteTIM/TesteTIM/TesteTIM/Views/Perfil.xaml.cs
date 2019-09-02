using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TesteTIM.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Perfil : ContentPage
	{
		public Perfil ()
		{
			InitializeComponent ();
        }

        public void TarefasCommand(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new Tarefas());
        }
        public void MainPageCommand(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}