using Cell.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cell.Paginas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListViewButtonPage : ContentPage
	{
		public ListViewButtonPage ()
		{
			InitializeComponent ();

            List<Funcionario> Lista = new List<Funcionario>();
            Lista.Add(new Funcionario() { Nome = "Jonata", Cargo = "CEO" });
            Lista.Add(new Funcionario() { Nome = "Silvia", Cargo = "Diretora" });
            Lista.Add(new Funcionario() { Nome = "Sarah", Cargo = "Gerente de Treinamento" });
            Lista.Add(new Funcionario() { Nome = "Allan", Cargo = "Administrador de Empresa" });
            Lista.Add(new Funcionario() { Nome = "Matheus", Cargo = "Gestor de TI" });

            ListaFuncionarios.ItemsSource = Lista;
        }

        private void FeriasAction(object sender, EventArgs args)
        {
            Button btnFerias = (Button)sender;
            Funcionario funcionario = (Funcionario)btnFerias.CommandParameter;

            DisplayAlert("Título: " + funcionario.Nome, "Mensagem: " + funcionario.Nome + " - Cargo: " + funcionario.Cargo, "OK");
        }
    }
}