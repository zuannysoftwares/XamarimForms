using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarefaXF.Modelos;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TarefaXF.Telas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Inicio : ContentPage
	{
		public Inicio ()
		{
			InitializeComponent ();
            DataHoje.Text = DateTime.Now.DayOfWeek.ToString() + ", " + DateTime.Now.ToString();
		}

        public void ActionGoCadastro(object sender, EventArgs args)
        {
            Navigation.PushAsync(new Cadastro());
        }

        private void CarregarTarefas()
        {
            SLTarefas.Children.Clear();
        }



        public void LinhaStackLayout(Tarefa tarefa) //Monta toda a estrutura do XAML
        {
            Image Delete = new Image() { VerticalOptions = LayoutOptions.Center, Source = ImageSource.FromFile("Delete.png") };
            if (Device.RuntimePlatform == Device.UWP)
                Delete.Source = ImageSource.FromFile("Resource/Delete.png");

            Image Prioridade = new Image() { VerticalOptions = LayoutOptions.Center, Source = ImageSource.FromFile("p" + tarefa.NomeTarefa + ".png") };
            if (Device.RuntimePlatform == Device.UWP)
                Prioridade.Source = ImageSource.FromFile("Resource/p" + tarefa.NomeTarefa + ".png");

            View StackCentral = null;

            if (tarefa.DataTarefa == null)
            {
                StackCentral = new Label() { VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.FillAndExpand, Text = tarefa.NomeTarefa };
            }
            else
            {
                StackCentral = new StackLayout() { VerticalOptions = LayoutOptions.Center, Spacing = 0, HorizontalOptions = LayoutOptions.FillAndExpand };
                ((StackLayout)StackCentral).Children.Add(new Label() { Text = tarefa.NomeTarefa, TextColor = Color.Gray });
                ((StackLayout)StackCentral).Children.Add(new Label() { Text = "Finalizado em " + tarefa.DataTarefa.ToString("dd/MM/yyyy - hh:mm") + "hs", TextColor = Color.Gray, FontSize = 10 });

            }
            
            Image checkBox = new Image() { VerticalOptions = LayoutOptions.Center, Source = ImageSource.FromFile("CheckOff.png") };
            if (Device.RuntimePlatform == Device.UWP)
                checkBox.Source = ImageSource.FromFile("Resource/CheckOff.png");

            StackLayout telaInicio = new StackLayout(){ Orientation = StackOrientation.Horizontal, Spacing = 15 };

            telaInicio.Children.Add(checkBox);
            telaInicio.Children.Add(StackCentral);
            telaInicio.Children.Add(Prioridade);
            telaInicio.Children.Add(Delete);

            SLTarefas.Children.Add(telaInicio);
        }


	}
}