using System;
using System.Collections.Generic;
using System.Globalization;
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

            CultureInfo culture = new CultureInfo("pt-BR");

            DateTime dia = DateTime.Now;

            for (int i = 1; i <= 7; i++)
            {
                DataHoje.Text = dia.ToString("D", culture);
            }

            CarregarTarefas();
        }

        public void ActionGoCadastro(object sender, EventArgs args)
        {
            Navigation.PushAsync(new Cadastro());
        }

        private void CarregarTarefas()
        {
            SLTarefas.Children.Clear();

            List<Tarefa> listTarefa = new GerenciadorTarefa().ListaTarefas();

            int i = 0;

            foreach (Tarefa lista in listTarefa)
            {
                LinhaStackLayout(lista, i);
                i++;
            }
        }

        public void LinhaStackLayout(Tarefa tarefa, int index) //Monta toda a estrutura do XAML
        {
            Image Delete = new Image() { VerticalOptions = LayoutOptions.Center, Source = ImageSource.FromFile("Delete.png") };
            if (Device.RuntimePlatform == Device.UWP)
                Delete.Source = ImageSource.FromFile("Resource/Delete.png");

            TapGestureRecognizer TapDelete = new TapGestureRecognizer();
            TapDelete.Tapped += delegate
            {
                new GerenciadorTarefa().RemoverTarefa(index);
                CarregarTarefas();
            };
            
            Delete.GestureRecognizers.Add(TapDelete);

            Image Prioridade = new Image() { VerticalOptions = LayoutOptions.Center, Source = ImageSource.FromFile("p" + tarefa.Prioridade + ".png") };
            if (Device.RuntimePlatform == Device.UWP)
                Prioridade.Source = ImageSource.FromFile("Resource/p" + tarefa.Prioridade + ".png");

            View StackCentral = null;

            if (tarefa.DataTarefa == null)
            {
                StackCentral = new Label() { VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.FillAndExpand, Text = tarefa.NomeTarefa };
            }
            else
            {
                StackCentral = new StackLayout() { VerticalOptions = LayoutOptions.Center, Spacing = 0, HorizontalOptions = LayoutOptions.FillAndExpand };
                ((StackLayout)StackCentral).Children.Add(new Label() { Text = tarefa.NomeTarefa, TextColor = Color.Gray });
                ((StackLayout)StackCentral).Children.Add(new Label() { Text = "Finalizada em " + tarefa.DataTarefa.Value.ToString("dd/MM/yyyy - HH:mm") + "hs", TextColor = Color.Gray, FontSize = 10 });

            }
            
            Image checkBox = new Image() { VerticalOptions = LayoutOptions.Center, Source = ImageSource.FromFile("CheckOff.png") };
            if (Device.RuntimePlatform == Device.UWP)
                checkBox.Source = ImageSource.FromFile("Resource/CheckOff.png");

            if(tarefa.DataTarefa != null)
            {
                checkBox.Source = ImageSource.FromFile("CheckOn.png");
                if (Device.RuntimePlatform == Device.UWP)
                    checkBox.Source = ImageSource.FromFile("Resource/CheckOn.png");

            }
            
            TapGestureRecognizer TapCheck = new TapGestureRecognizer();
            TapCheck.Tapped += delegate
            {
                new GerenciadorTarefa().FinalizarTarefa(index, tarefa);
                CarregarTarefas();
            };

            checkBox.GestureRecognizers.Add(TapCheck);

            StackLayout telaInicio = new StackLayout(){ Orientation = StackOrientation.Horizontal, Spacing = 15 };

            telaInicio.Children.Add(checkBox);
            telaInicio.Children.Add(StackCentral);
            telaInicio.Children.Add(Prioridade);
            telaInicio.Children.Add(Delete);

            SLTarefas.Children.Add(telaInicio);
        }


	}
}