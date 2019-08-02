using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ControleXF.Controles
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SwichPage : ContentPage
	{
		public SwichPage ()
		{
			InitializeComponent ();
		}

        private void AcionarToggle(object sender, ToggledEventArgs args)
        {
            Trocou.Text = DateTime.Now.ToString("HH:mm") + " - " + (args.Value.ToString().Equals("True") ? "Ligado" : "Desligado");
        }
    }
}