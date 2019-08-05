using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using TestDrive.Models;
using TestDrive.Views;
using Xamarin.Forms;

namespace TestDrive.ViewModels
{
    public class AgendamentoViewModel : BaseViewModel
    {
        const string URL_POST_AGENDAMENTO = "https://aluracar.herokuapp.com/salvaragendamento";
        public Agendamento agendamento { get; set; }
        public Veiculo Carro
        {
            get
            {
                return agendamento.Carro;
            }
            set
            {
                agendamento.Carro = value;
            }
        }
        public string Nome
        {
            get
            {
                return agendamento.Nome;
            }
            set
            {
                agendamento.Nome = value;
                OnPropertyChanged();
                ((Command)Agendar).ChangeCanExecute();
            }
        }
        public string Telefone
        {
            get
            {
                return agendamento.Telefone;
            }
            set
            {
                agendamento.Telefone = value;
                OnPropertyChanged();
                ((Command)Agendar).ChangeCanExecute();
            }
        }
        public string Email
        {
            get
            {
                return agendamento.Email;
            }
            set
            {
                agendamento.Email = value;
                OnPropertyChanged();
                ((Command)Agendar).ChangeCanExecute();
            }
        }
        public DateTime DataAgenda
        {
            get
            {
                return agendamento.DataAgenda;
            }
            set
            {
                agendamento.DataAgenda = value;
            }
        }
        public TimeSpan HoraAgenda
        {
            get
            {
                return agendamento.HoraAgenda;
            }
            set
            {
                agendamento.HoraAgenda = value;
            }
        }

        public AgendamentoViewModel(Veiculo car)
        {
            this.agendamento = new Agendamento();
            this.agendamento.Carro = car;

            Agendar = new Command(() => //Função anônima
            {
                MessagingCenter.Send<Agendamento>(this.agendamento, "Agendamento");
            }, () =>//Função anônima
            {
                return 
                !string.IsNullOrEmpty(this.Nome) 
                && !string.IsNullOrEmpty(this.Telefone) 
                && !string.IsNullOrEmpty(this.Email);

            });
        }

        public ICommand Agendar { get; set; }

        public async void SalvaAgendamento()
        {
            HttpClient client = new HttpClient();

            var dataHoraAgendamento = new DateTime(
                DataAgenda.Year, 
                DataAgenda.Month, 
                DataAgenda.Day, 
                HoraAgenda.Hours, 
                HoraAgenda.Minutes, 
                HoraAgenda.Seconds
                );


            var model = JsonConvert.SerializeObject(new
            {
                nome = Nome,
                fone = Telefone,
                email = Email,
                carro = Carro.Nome,
                preco = Carro.Preco,
                dataAgendamento = dataHoraAgendamento
            });

            var content = new StringContent(model, Encoding.UTF8, "application/json");
            var result = await client.PostAsync(URL_POST_AGENDAMENTO, content);

            if (result.IsSuccessStatusCode)
                MessagingCenter.Send<Agendamento>(this.agendamento, "SucessoAgendamento");
            else
                MessagingCenter.Send<ArgumentException>(new ArgumentException(), "FalhaAgendamento");
        }

    }
}
