using AppVagas.DAO;
using AppVagas.Models;
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
	public partial class EditarVaga : ContentPage
	{
        private Vagas _vaga { get; set; }
		public EditarVaga (Vagas vaga)
		{
			InitializeComponent ();

            this._vaga = vaga;

            NomeVaga.Text             = _vaga.NomeVaga;
            Empresa.Text              = _vaga.Empresa;
            Quantidade.Text           = _vaga.Quantidade.ToString();
            Cidade.Text               = _vaga.Cidade;
            Salario.Text              = _vaga.Salario.ToString();
            DescricaoVaga.Text        = _vaga.DescricaoVaga;
            TipoContratacao.IsToggled = (_vaga.TipoContratacao == "CLT") ? false : true;
            Email.Text                = _vaga.Email;
            Telefone.Text             = _vaga.Telefone;
        }

        public void SalvarEdicao(object sender, EventArgs args)
        {
            _vaga.NomeVaga       = NomeVaga.Text;
            _vaga.Empresa        = Empresa.Text;
            _vaga.Quantidade     = short.Parse(Quantidade.Text);
            _vaga.Cidade         = Cidade.Text;
            _vaga.Salario        = double.Parse(Salario.Text);
            _vaga.DescricaoVaga  = DescricaoVaga.Text;
            _vaga.TipoContratacao = (TipoContratacao.IsToggled) ? "PJ" : "CLT";
            _vaga.Email = Email.Text;
            _vaga.Telefone = Telefone.Text;

            AcessoBanco db = new AcessoBanco();
            db.AtualizarVagas(_vaga);

            App.Current.MainPage = new NavigationPage(new ListaVagas());
        }
    }
}