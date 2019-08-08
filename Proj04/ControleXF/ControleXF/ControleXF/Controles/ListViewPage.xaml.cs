using ControleXF.Modelo;
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
	public partial class ListViewPage : ContentPage
	{
		public ListViewPage ()
		{
			InitializeComponent ();

            List<Pessoa> lista = new List<Pessoa>();
            lista.Add(new Pessoa { nome = "Jonata Rafael", idede = 31 });
            lista.Add(new Pessoa { nome = "Silvia Helena", idede = 47 });
            lista.Add(new Pessoa { nome = "Allan Rodrigo", idede = 28 });
            lista.Add(new Pessoa { nome = "Sarah Gouveia", idede = 35 });
            lista.Add(new Pessoa { nome = "Doracy Terezinha", idede = 77 });

            ListaPessoas.ItemsSource = lista;
		}
	}
}