using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App_Layout2.Master
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Menu : MasterDetailPage
    {
		public Menu ()
		{
			InitializeComponent ();
		}

        private void GoPaginaPerfil1(object sender, EventArgs args)
        {
            Detail = new Pages.Perfil1();
        }

        private void GoPaginaSobre(object sender, EventArgs args)
        {
            Detail = new Pages.Sobre();
        }
    }
}