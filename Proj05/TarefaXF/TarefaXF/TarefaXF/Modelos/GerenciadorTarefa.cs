using Newtonsoft.Json;
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
        public void RemoverTarefa(int index)
        {
            lista = ListaTarefas();
            lista.RemoveAt(index);

            SalvarNoProperties(lista);
        }
        public void FinalizarTarefa(int index, Tarefa tarefa)
        {
            lista = ListaTarefas();
            lista.RemoveAt(index);

            tarefa.DataTarefa = DateTime.Now;

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

            string json = JsonConvert.SerializeObject(lista);

            App.Current.Properties.Add("Tarefas", json);
        }

        private List<Tarefa> ListaNoProperties()
        {
            if (App.Current.Properties.ContainsKey("Tarefas"))
            {
                string json = (string)App.Current.Properties["Tarefas"];

                List<Tarefa> Lista = JsonConvert.DeserializeObject<List<Tarefa>>(json);

                return Lista;
            }

            return new List<Tarefa>();
        }
    }
}
