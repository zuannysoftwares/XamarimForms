using App_Mimica.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App_Mimica.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Jogo : ContentPage
	{
		public Jogo (GrupoModel grupo)
		{
			InitializeComponent ();
            BindingContext = new ViewModel.JogoViewModel(grupo);
		}
	}
}