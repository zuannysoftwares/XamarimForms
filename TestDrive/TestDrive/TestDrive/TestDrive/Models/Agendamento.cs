using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using TestDrive.Models;

namespace TestDrive.Views
{
    public class Agendamento
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Modelo { get; set; }
        public bool Confirmado { get; set; }

        public decimal Preco { get; set; }

        public string Nome { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }

        DateTime dataAg = DateTime.Today;
        public DateTime DataAgenda
        {
            get
            {
                return dataAg;
            }
            set
            {
                dataAg = value;
            }
        }

        public TimeSpan HoraAgenda { get; set; }

        public string DataFormatada {
            get
            {
                return DataAgenda.Add(HoraAgenda).ToString("dd/MM/yyyy HH:mm");
            }
        }

        public Agendamento()
        {

        }

        public Agendamento(string nome, string telefone, string email, string modelo, decimal preco, DateTime dataAgendamento, TimeSpan horaAgendamento) 
            : this(nome, telefone, email, modelo, preco)
        {
            this.DataAgenda = dataAgendamento;
            this.HoraAgenda = horaAgendamento;
        }

        public Agendamento(string nome, string telefone, string email, string modelo, decimal preco)
        {
            this.Nome = nome;
            this.Telefone = telefone;
            this.Email = email;
            this.Modelo = modelo;
            this.Preco = preco;
        }
    }
}
