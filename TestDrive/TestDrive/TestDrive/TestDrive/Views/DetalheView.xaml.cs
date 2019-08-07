using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDrive.Models;
using TestDrive.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestDrive.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetalheView : ContentPage
    {
        public Veiculo Carro { get; private set; }

        public Usuario Usuario { get; private set; }
        public DetalheView(Veiculo carro, Usuario user)
        {
            InitializeComponent();
            this.Carro = carro;
            this.Usuario = user;
            this.BindingContext = new DetalheViewModel(carro);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Veiculo>(this, "Proximo", (veiculo) =>
            {
                Navigation.PushAsync(new AgendamentoView(veiculo, this.Usuario));
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Veiculo>(this, "Proximo");
        }
    }
}