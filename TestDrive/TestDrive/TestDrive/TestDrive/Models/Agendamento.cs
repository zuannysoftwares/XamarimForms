using System;
using System.Collections.Generic;
using System.Text;
using TestDrive.Models;

namespace TestDrive.Views
{
    public class Agendamento
    {
        public Veiculo Carro { get; set; }
        
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

    }
}
