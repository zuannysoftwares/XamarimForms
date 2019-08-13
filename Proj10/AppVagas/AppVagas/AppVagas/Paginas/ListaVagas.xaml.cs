using AppVagas.Models;
using AppVagas.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppVagas.Paginas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListaVagas : ContentPage
	{
        List<Vagas> lista { get; set; }
        public ListaVagas ()
		{
			InitializeComponent ();

            RecarregaListaVagas();
        }

        public void EditarVaga(object sender, EventArgs args)
        {
            Label lblEditar = (Label)sender;
            Vagas vaga = ((TapGestureRecognizer)lblEditar.GestureRecognizers[0]).CommandParameter as Vagas;

            Navigation.PushAsync(new Paginas.EditarVaga(vaga));
        }

        public void ExcluirVaga(object sender, EventArgs args)
        {
            Label lblExcluir = (Label)sender;
            Vagas vaga = ((TapGestureRecognizer)lblExcluir.GestureRecognizers[0]).CommandParameter as Vagas;

            AcessoBanco db = new AcessoBanco();
            db.ExcluirVaga(vaga);

            RecarregaListaVagas();
        }

        private void RecarregaListaVagas()
        {
            AcessoBanco db = new AcessoBanco();
            lista = db.ListaVagas();
            ListaTodasVagas.ItemsSource = lista;

            int contadorVagas = lista.Count;

            if (contadorVagas > 0 || contadorVagas == 1)
                lblTodasVagas.Text = contadorVagas + " vaga encontrada";

            if (contadorVagas > 0 && contadorVagas > 1)
                lblTodasVagas.Text = contadorVagas + " vagas encontradas";

            if (contadorVagas == 0)
                lblTodasVagas.Text = "Nenhuma vaga encontrada";
        }

        public void PesquisaAction(object sender, TextChangedEventArgs args)
        {
            ListaTodasVagas.ItemsSource = lista.Where(l => l.NomeVaga.Contains(args.NewTextValue)).ToList();
        }
    }
}