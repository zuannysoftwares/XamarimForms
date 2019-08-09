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
        readonly Usuario usuario;

        public ListagemPrincipal(Usuario user)
        {
            InitializeComponent();
            this.ViewModel = new ListagemViewModel();
            this.usuario = user;
            this.BindingContext = this.ViewModel;
        }

        protected async override void OnAppearing()//Ao aparecer
        {
            base.OnAppearing();

            AssinarMensagens();

            await this.ViewModel.GetVeiculos();
        }

        private void AssinarMensagens()
        {
            MessagingCenter.Subscribe<Veiculo>(this, "VeiculoSelecionado", (veiculo) => { Navigation.PushAsync(new DetalheView(veiculo, this.usuario)); });

            MessagingCenter.Subscribe<Exception>(this, "FalhaListagem", (msg) =>
            {
                DisplayAlert("Erro", "Ocorreu um erro ao obter lista de veículos", "OK");
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            CancelarAssinatura();
        }

        private void CancelarAssinatura()
        {
            MessagingCenter.Unsubscribe<Veiculo>(this, "VeiculoSelecionado");
            MessagingCenter.Unsubscribe<Exception>(this, "FalhaListagem");
        }
    }
}
