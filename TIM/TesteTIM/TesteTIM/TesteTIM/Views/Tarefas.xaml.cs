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
	public partial class Tarefas : ContentPage
	{
		public Tarefas ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        public void MainPageCommand(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new MainPage());
        }

        private void PerfilCommand(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Perfil());
        }

        private void VoltarCommand(object sender, EventArgs args)
        {
            Application.Current.MainPage = new NavigationPage(new MainPage());

        }
    }
}