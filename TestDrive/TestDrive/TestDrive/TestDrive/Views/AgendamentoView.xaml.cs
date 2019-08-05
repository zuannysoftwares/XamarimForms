using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestDrive.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AgendamentoView : ContentPage
	{

        public Veiculo Carro { get; set; }

        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        DateTime dataAg = DateTime.Today;
        public DateTime DataAgenda {
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
        
        public AgendamentoView (Veiculo car)
		{
			InitializeComponent ();
            this.Carro = car;
            this.BindingContext = this;
		}

        private void Agendar(object sender, EventArgs args)
        {
            DisplayAlert("Agendamento de Test Drive", string.Format("" +
@"Cliente: {0}
Telefone: {1}
E-mail: {2}
----------------------------------
Veículo: {3}
Agendamento: {4}
Hora: {5}", Nome, Telefone, Email, Carro.Nome, DataAgenda.ToString("dd/MM/yyyy"), HoraAgenda), "OK");
        }
	}
}