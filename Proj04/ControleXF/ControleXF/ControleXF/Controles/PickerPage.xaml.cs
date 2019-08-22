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
	public partial class PickerPage : ContentPage
	{
		public PickerPage ()
		{
			InitializeComponent ();
		}

        private void ValorSelecionado(object sender, EventArgs args)
        {
            Picker obj = (Picker)sender;
            result.Text = "Indice:" + obj.SelectedIndex + " - " + obj.SelectedItem.ToString();
        }
    }
}