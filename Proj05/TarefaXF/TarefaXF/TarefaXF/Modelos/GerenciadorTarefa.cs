using System;
using System.Collections.Generic;
using System.Text;

namespace TarefaXF.Modelos
{
    public class GerenciadorTarefa
    {
        private List<Tarefa> lista { get; set; }
        public void Salvar(Tarefa tarefa)
        {
            lista = ListaTarefas();
            lista.Add(tarefa);

            SalvarNoProperties(lista);
            
        }
        public void RemoverTarefa(Tarefa tarefa)
        {
            lista = ListaTarefas();
            lista.Remove(tarefa);

            SalvarNoProperties(lista);
        }
        public void FinalizarTarefa(int index, Tarefa tarefa)
        {
            lista = ListaTarefas();
            lista.RemoveAt(index);

            lista.Add(tarefa);

            SalvarNoProperties(lista);
        }

        public List<Tarefa> ListaTarefas()
        {
            return ListaNoProperties();
        }

        private void SalvarNoProperties(List<Tarefa> lista)
        {
            if (App.Current.Properties.ContainsKey("Tarefas"))
            {
                App.Current.Properties.Remove("Tarefas");
            }

            App.Current.Properties.Add("Tarefas", lista);
        }

        private List<Tarefa> ListaNoProperties()
        {
            if (App.Current.Properties.ContainsKey("Tarefas"))
            {
                return (List<Tarefa>)App.Current.Properties["Tarefas"];
            }
            return new List<Tarefa>();
        }
    }
}
