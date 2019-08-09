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
    public partial class AgendamentoView : ContentPage
    {
        public AgendamentoViewModel viewModel { get; set; }

        public Agendamento agendamento { get; set; }

        public AgendamentoView(Veiculo car, Usuario user)
        {
            InitializeComponent();
            this.viewModel = new AgendamentoViewModel(car, user);
            this.BindingContext = this.viewModel;
        }

        protected override void OnAppearing()//Ao aparecer
        {
            base.OnAppearing();
            AssinarMensagens();
        }

        private void AssinarMensagens()
        {
            MessagingCenter.Subscribe<Agendamento>(this, "Agendamento",
                           async (msg) =>
                           {
                               var confirma = await DisplayAlert("Salvar agendamento",
                       "Tem certeza de que quer enviar o agendamento?",
                       "SIM", "NÃO");

                               if (confirma)
                               {
                                   this.viewModel.SalvaAgendamento();
                               }
                           });

            MessagingCenter.Subscribe<Agendamento>(this, "SucessoAgendamento",
               async (msg) =>
               {
                   await DisplayAlert("Agendamento", "Agendamento salvo com sucesso!", "OK");
                   await Navigation.PopToRootAsync();

               });

            MessagingCenter.Subscribe<ArgumentException>(this, "FalhaAgendamento",
            async (msg) =>
            {
                await DisplayAlert("Agendamento", "Falha ao agendar o TestDrive. Verifique os dados e tente novamente mais tarde", "OK");
                await Navigation.PopToRootAsync();
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Agendamento>(this, "Agendamento");

            MessagingCenter.Unsubscribe<Agendamento>(this, "SucessoAgendamento");

            MessagingCenter.Unsubscribe<ArgumentException>(this, "FalhaAgendamento");
        }
    }
}