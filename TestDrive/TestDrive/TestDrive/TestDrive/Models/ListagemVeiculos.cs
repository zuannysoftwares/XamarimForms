using System;
using System.Collections.Generic;
using System.Text;

namespace TestDrive.Models
{
    public class ListagemVeiculos
    {
        public List<Veiculo> Veiculos { get; set; }
        public ListagemVeiculos()
        {
            this.Veiculos = new List<Veiculo>
            {
                new Veiculo {Nome = "Onix",               Preco = 35400},
                new Veiculo {Nome = "Uno Fire",           Preco = 10400},
                new Veiculo {Nome = "Astra Sedan",        Preco = 27850},
                new Veiculo {Nome = "Fusion",             Preco = 77980},
                new Veiculo {Nome = "HB20",               Preco = 27000},
                new Veiculo {Nome = "Montana",            Preco = 37390},
                new Veiculo {Nome = "Citröen C4 Pallace", Preco = 43570},
                new Veiculo {Nome = "Hilux",              Preco = 87690}
            };
        }
    }
}
