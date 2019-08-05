using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using TestDrive.Models;
using TestDrive.ViewModels;

namespace TestDrive.Views
{
    public partial class ListagemPrincipal : ContentPage
    {

        public ListagemViewModel ViewModel { get; set; }
        public ListagemPrincipal()
        {
            InitializeComponent();
            this.ViewModel = new ListagemViewModel();
            this.BindingContext = this.ViewModel;
        }

        protected async override void OnAppearing()//Ao aparecer
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<Veiculo>(this, "VeiculoSelecionado", (msg) => { Navigation.PushAsync(new DetalheView(msg)); });

            await this.ViewModel.GetVeiculos();

        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Veiculo>(this, "VeiculoSelecionado");
        }
    }
}
