using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using TestDrive.Data;
using TestDrive.Views;
using Xamarin.Forms;

namespace TestDrive.ViewModels
{
    public class AgendamentosUsuarioViewModel : BaseViewModel
    {
        ObservableCollection<Agendamento> listaAgendamento = new ObservableCollection<Agendamento>();
        public ObservableCollection<Agendamento> ListaAgendamentos
        {
            get
            {
                return listaAgendamento;
            }
            private set
            {
                listaAgendamento = value;
                OnPropertyChanged();
            }
        }

        private Agendamento agendamentoSelecionado;

        public Agendamento AgendamentoSelecionado
        {
            get { return agendamentoSelecionado; }
            set
            {
                if(value != null)
                {
                    agendamentoSelecionado = value;
                    MessagingCenter.Send<Agendamento>(agendamentoSelecionado, "AgendamentoSelecionado");
                }
            }
        }

        public AgendamentosUsuarioViewModel()
        {
            AtualizarLista();
        }

        public void AtualizarLista()
        {
            using (var conex = DependencyService.Get<ISqlite>().RetornaConexao())
            {
                AgendamentoDAO dao = new AgendamentoDAO(conex);

                var listaDB = dao.Lista;

                var query = listaDB //Ordena a exibição por Data e Hora
                    .OrderBy(l => l.DataAgenda)
                    .ThenBy(l => l.HoraAgenda);

                this.ListaAgendamentos.Clear();

                foreach (var item in query)
                {
                    this.ListaAgendamentos.Add(item);
                }
            }
        }
    }
}
