using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TestDrive.Views
{
    public class Veiculo
    {
        public decimal Preco { get; set; }
        public string PrecoFormatado {
            get { return string.Format("R$ {0}", Preco); }
        }
        public string Nome { get; set; }
    }


    public partial class ListagemPrincipal : ContentPage
    {
        public List<Veiculo> Veiculos { get; set; }

        public ListagemPrincipal()
        {
            InitializeComponent();

            this.Veiculos = new List<Veiculo>
            {
                new Veiculo {Nome = "Onix", Preco = 35400},
                new Veiculo {Nome = "Uno Fire", Preco = 10400},
                new Veiculo {Nome = "Astra Sedan", Preco = 27850},
                new Veiculo {Nome = "Fusion", Preco = 77980},
                new Veiculo {Nome = "HB20", Preco = 27000},
                new Veiculo {Nome = "Montana", Preco = 37390},
                new Veiculo {Nome = "Citröen C4 Pallace", Preco = 43570},
                new Veiculo {Nome = "Hilux", Preco = 87690}
            };

            this.BindingContext = this;
        }

        private void VeiculoSelecionado(object sender, ItemTappedEventArgs args)
        {
            var veiculo = (Veiculo)args.Item;

            Navigation.PushAsync(new DetalheView(veiculo));

        }
    }
}
