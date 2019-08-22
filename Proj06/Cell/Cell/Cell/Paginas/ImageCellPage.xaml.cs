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
	public partial class ImageCellPage : ContentPage
	{
		public ImageCellPage ()
		{
			InitializeComponent ();

            List<Funcionario> Lista = new List<Funcionario>();
            Lista.Add(new Funcionario() { Foto = "xamarin1.png", Nome = "Tamires", Cargo = "CEO" });
            Lista.Add(new Funcionario() { Foto = "perfil5.png", Nome = "Silvia", Cargo = "Diretora" });
            Lista.Add(new Funcionario() { Foto = "perfil5.png", Nome = "Sarah", Cargo = "Gerente de Treinamento" });
            Lista.Add(new Funcionario() { Foto = "perfil5.png", Nome = "Allan", Cargo = "Administrador de Empresa" });
            Lista.Add(new Funcionario() { Foto = "perfil5.png", Nome = "Thamires", Cargo = "Gestora de TI" });

            ListaFuncionarios.ItemsSource = Lista;
        }
	}
}