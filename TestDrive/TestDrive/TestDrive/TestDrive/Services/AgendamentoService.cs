using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using TestDrive.Data;
using TestDrive.Views;
using Xamarin.Forms;

namespace TestDrive.Services
{
    public class AgendamentoService
    {
        public async System.Threading.Tasks.Task EnviarAgendamento(Agendamento agendamento)
        {
            HttpClient client = new HttpClient();
            const string URL_POST_AGENDAMENTO = "https://aluracar.herokuapp.com/salvaragendamento";

            var dataHoraAgendamento = new DateTime(
                agendamento.DataAgenda.Year,
                agendamento.DataAgenda.Month,
                agendamento.DataAgenda.Day,
                agendamento.HoraAgenda.Hours,
                agendamento.HoraAgenda.Minutes,
                agendamento.HoraAgenda.Seconds
                );

            var model = JsonConvert.SerializeObject(new
            {
                nome = agendamento.Nome,
                fone = agendamento.Telefone,
                email = agendamento.Email,
                carro = agendamento.Modelo,
                preco = agendamento.Preco,
                dataAgendamento = dataHoraAgendamento
            });

            var content = new StringContent(model, Encoding.UTF8, "application/json");
            var result = await client.PostAsync(URL_POST_AGENDAMENTO, content);

            agendamento.Confirmado = result.IsSuccessStatusCode;

            SalvarAgendamentoDB(agendamento);

            if (agendamento.Confirmado)
                MessagingCenter.Send<Agendamento>(agendamento, "SucessoAgendamento");
            else
                MessagingCenter.Send<ArgumentException>(new ArgumentException(), "FalhaAgendamento");
        }

        private void SalvarAgendamentoDB(Agendamento agendamento)
        {
            using (var conexao = DependencyService.Get<ISqlite>().RetornaConexao())
            {
                AgendamentoDAO dao = new AgendamentoDAO(conexao);
                dao.Salvar(agendamento);
            }
        }
    }
}
