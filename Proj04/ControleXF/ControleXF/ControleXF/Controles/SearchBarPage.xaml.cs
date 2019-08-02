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
	public partial class SearchBarPage : ContentPage
	{
        private List<string> empresas;
		public SearchBarPage ()
		{
			InitializeComponent ();

            empresas = new List<string>();
            empresas.Add("Uber");
            empresas.Add("Microsoft");
            empresas.Add("Oracle");
            empresas.Add("Apple");
            empresas.Add("Tesla");
            empresas.Add("Google");
            empresas.Add("Squadra");

            PreencherLista(empresas);
        }

        private void PesquisarButon(object sender, EventArgs args)
        {
            var result = empresas.Where(x => x.Contains(((SearchBar)sender).Text)).ToList();
            PreencherLista(result);
        }
        private void Pesquisar(object sender, TextChangedEventArgs args)
        {
            var result =  empresas.Where(x => x.Contains(args.NewTextValue)).ToList();
            PreencherLista(result);
        }

        private void PreencherLista(List<string> listaEmpresas)
        {
            ListaResults.Children.Clear();

            foreach (var item in listaEmpresas)
            {
                ListaResults.Children.Add(new Label { Text = item });
            }
        }
	}
}