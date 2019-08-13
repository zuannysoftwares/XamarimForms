using AppVagas.Models;
using AppVagas.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppVagas.Paginas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CadastroVagas : ContentPage
	{
		public CadastroVagas ()
		{
			InitializeComponent ();
		}

        public void SalvarVaga(object sender, EventArgs args)
        {
            Vagas vaga = new Vagas();
            vaga.NomeVaga = Vaga.Text;
            vaga.Empresa = Empresa.Text;
            vaga.Quantidade = short.Parse(Quantidade.Text);
            vaga.Cidade = Cidade.Text;
            vaga.Salario = Convert.ToDouble(Salário.Text);
            vaga.DescricaoVaga = Descricao.Text;
            vaga.TipoContratacao = (TipoContratacao.IsToggled) ? "PJ" : "CLT";
            vaga.Email = Email.Text;
            vaga.Telefone = Telefone.Text;

            AcessoBanco db = new AcessoBanco();
            db.CadastrarVaga(vaga);

            App.Current.MainPage = new NavigationPage(new ConsultaVagas());
        }

    }
}