using ListaMunicipios.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ListaMunicipios
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Municipios : ContentPage
	{
        private List<Municipio> _listaMuni { get; set; }
        private List<Municipio> _resultBuscaRapida { get; set; }

		public Municipios (Estado estado)
		{
			InitializeComponent ();

            _listaMuni = Servico.Service.GetMunicipios(estado.id);
            ListaMunicipios.ItemsSource = _listaMuni;
		}

        private void BuscaRapida(object sender, TextChangedEventArgs args)
        {
            _resultBuscaRapida = _listaMuni.Where(l => l.nome.Contains(args.NewTextValue)).ToList();

            ListaMunicipios.ItemsSource = _resultBuscaRapida;

        }
    }
}