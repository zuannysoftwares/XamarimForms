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
	public partial class Cadastro : ContentPage
	{
        private byte prioridade { get; set; }

		public Cadastro ()
		{
			InitializeComponent ();

		}

        public void PrioridadeSelectAction(object sender, EventArgs args)
        {
            //Método usado para quando o usuário tocar em alguma imagem do app,
            //Faz com que o nome fique mais escuro.

            var stacks = SLPrioridades.Children;

            foreach (var linha in stacks)
            {
                Label lblPrioridade = ((StackLayout)linha).Children[1] as Label;
                lblPrioridade.TextColor = Color.Gray;
            }

            ((Label)((StackLayout)sender).Children[1]).TextColor = Color.Black;
            FileImageSource Source = ((Image)((StackLayout)sender).Children[0]).Source as FileImageSource;

            string nomeImagem = Source.File.ToString().Replace("p", "").Replace(".ng", "");

            this.prioridade = byte.Parse(nomeImagem);
        }
        public void SalvarAction(object sender, EventArgs args)
        {
            bool retornoErro = false;

            if (!(txtNome.Text.Trim().Length > 0))
            {
                retornoErro = true;
                DisplayAlert("ERRO", "Nome não preenchido.", "OK");
            }
            if (!(this.prioridade > 0))
            {
                retornoErro = true;
                DisplayAlert("ERRO", "Prioridade não foi informada.", "OK");
            }

            if (retornoErro == false)
            {
                Tarefa tarefa = new Tarefa();
                tarefa.NomeTarefa = txtNome.Text.Trim();
                tarefa.Prioridade = this.prioridade;

                new GerenciadorTarefa().Salvar(tarefa);

                App.Current.MainPage = new NavigationPage(new Inicio()); //Força que a página inicio seja "criada" novamente
            }
        }

    }
}