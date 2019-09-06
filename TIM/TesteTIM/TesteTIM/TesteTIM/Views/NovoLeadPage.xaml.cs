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
	public partial class NovoLeadPage : ContentPage
	{
		public NovoLeadPage ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void VoltarCommand(object sender, EventArgs args)
        {
            Application.Current.MainPage = new NavigationPage(new MainPage());

        }
    }
}