using AppVagas.DAO;
using AppVagas.Models;
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
    public partial class ConsultaVagas : ContentPage
    {
        List<Vagas> lista { get; set; }

        public ConsultaVagas()
        {
            InitializeComponent();

            AcessoBanco db = new AcessoBanco();
            lista = db.ListaVagas();
            ListaVagasConsulta.ItemsSource = lista;

            int contadorVagas = lista.Count;

            if (contadorVagas > 0 || contadorVagas == 1)
                lblPesquisaDeVagas.Text = contadorVagas + " vaga encontrada";

            if(contadorVagas > 0 && contadorVagas > 1)
                lblPesquisaDeVagas.Text = contadorVagas + " vagas encontradas";

            if(contadorVagas == 0)
                lblPesquisaDeVagas.Text = "Nenhuma vaga encontrada";
        }

        public void GoCadastro(object sender, EventArgs args)
        {
            Navigation.PushAsync(new Paginas.CadastroVagas());
        }

        public void GoListarVagas(object sender, EventArgs args)
        {
            Navigation.PushAsync(new Paginas.ListaVagas());
        }

        public void MaisDetalhe(object sender, EventArgs args)
        {
            Label lblDetalhe = (Label)sender;
            Vagas vaga = ((TapGestureRecognizer)lblDetalhe.GestureRecognizers[0]).CommandParameter as Vagas;

            Navigation.PushAsync(new Paginas.DetalheVaga(vaga));
        }

        public void PesquisarAction(object sender, TextChangedEventArgs args)
        {
            ListaVagasConsulta.ItemsSource = lista.Where(l => l.NomeVaga.Contains(args.NewTextValue)).ToList();
        }
    }
}