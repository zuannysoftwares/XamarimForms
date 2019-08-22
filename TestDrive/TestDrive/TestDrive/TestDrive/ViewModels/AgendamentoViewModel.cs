using System;
using System.Windows.Input;
using TestDrive.Models;
using TestDrive.Services;
using TestDrive.Views;
using Xamarin.Forms;

namespace TestDrive.ViewModels
{
    public class AgendamentoViewModel : BaseViewModel
    {
        public Agendamento Agendamento { get; set; }
        public string Modelo
        {
            get { return this.Agendamento.Modelo; }
            set { this.Agendamento.Modelo = value; }
        }
        public decimal Preco
        {
            get { return this.Agendamento.Preco; }
            set { this.Agendamento.Preco = value; }
        }
        public string Nome
        {
            get
            {
                return Agendamento.Nome;
            }
            set
            {
                Agendamento.Nome = value;
                OnPropertyChanged();
                ((Command)Agendar).ChangeCanExecute();
            }
        }
        public string Telefone
        {
            get
            {
                return Agendamento.Telefone;
            }
            set
            {
                Agendamento.Telefone = value;
                OnPropertyChanged();
                ((Command)Agendar).ChangeCanExecute();
            }
        }
        public string Email
        {
            get
            {
                return Agendamento.Email;
            }
            set
            {
                Agendamento.Email = value;
                OnPropertyChanged();
                ((Command)Agendar).ChangeCanExecute();
            }
        }
        public DateTime DataAgenda
        {
            get
            {
                return Agendamento.DataAgenda;
            }
            set
            {
                Agendamento.DataAgenda = value;
            }
        }
        public TimeSpan HoraAgenda
        {
            get
            {
                return Agendamento.HoraAgenda;
            }
            set
            {
                Agendamento.HoraAgenda = value;
            }
        }
        public ICommand Agendar { get; set; }

        public AgendamentoViewModel(Veiculo car, Usuario usuario)
        {
            this.Agendamento = new Agendamento(usuario.nome, usuario.telefone, usuario.email, car.Nome, car.Preco);

            Agendar = new Command(() => //Função anônima
            {
                MessagingCenter.Send<Agendamento>(this.Agendamento, "Agendamento");
            }, () =>//Função anônima
            {
                return
                !string.IsNullOrEmpty(this.Nome)
                && !string.IsNullOrEmpty(this.Telefone)
                && !string.IsNullOrEmpty(this.Email);

            });
        }

        public async void SalvaAgendamento()
        {
            AgendamentoService agendamentoService = new AgendamentoService();
            await agendamentoService.EnviarAgendamento(this.Agendamento);
        }

    }
}
