using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App_Mimica.View.Util
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Cabecalho : ContentView
	{
		public Cabecalho ()
		{
			InitializeComponent ();
            BindingContext = new ViewModel.CabecalhoViewModel();
		}

        public void ReiniciarEvento(object sender, EventArgs args)
        {
            var viewModel = (ViewModel.CabecalhoViewModel)this.BindingContext;

            if(viewModel.ReiniciarJogo.CanExecute(null))
            {
                viewModel.ReiniciarJogo.Execute(null);
            }

        }
    }
}