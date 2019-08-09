using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestDrive.Services;
using TestDrive.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestDrive.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgendamentosUsuarioView : ContentPage
    {
        readonly AgendamentosUsuarioViewModel _viewModel;
        public AgendamentosUsuarioView()
        {
            InitializeComponent();
            this._viewModel = new AgendamentosUsuarioViewModel();
            this.BindingContext = this._viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            AssinaturaMensagens();

        }

        private void AssinaturaMensagens()
        {
            MessagingCenter.Subscribe<Agendamento>(this, "AgendamentoSelecionado", async (agendamento) =>
            {
                if (!agendamento.Confirmado)
                {
                    var reenviar = await DisplayAlert("Reenviar Agendamento", "Deseja reenviar o agendamento?", "SIM", "NÃO");

                    if (reenviar)
                    {
                        AgendamentoService agendamentoService = new AgendamentoService();
                        await agendamentoService.EnviarAgendamento(agendamento);
                        this._viewModel.AtualizarLista();
                    }
                }
            });

            MessagingCenter.Subscribe<Agendamento>(this, "SucessoAgendamento", async (agendamento) =>
            {
                await DisplayAlert("Reenviar", "Reenvio realizado com sucesso.", "OK");
            });

            MessagingCenter.Subscribe<Agendamento>(this, "FalhaAgendamento", async (agendamento) =>
            {
                await DisplayAlert("Reenviar", "Erro ao reenviar o agendamento. Tente novamente.", "OK");
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            CancelarAssinaturas();
        }

        private void CancelarAssinaturas()
        {
            MessagingCenter.Unsubscribe<Agendamento>(this, "AgendamentoSelecionado");
            MessagingCenter.Unsubscribe<Agendamento>(this, "SucessoAgendamento");
            MessagingCenter.Unsubscribe<Agendamento>(this, "FalhaAgendamento");
        }
    }
}