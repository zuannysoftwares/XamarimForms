using System;
using System.Collections.Generic;
using System.Text;
using TestDrive.Models;
using Xamarin.Forms;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace TestDrive.ViewModels
{
    public class ListagemViewModel : BaseViewModel
    {
        const string URL_GET_VEICULOS = "https://aluracar.herokuapp.com/";
        public ObservableCollection<Veiculo> Veiculos { get; set; }
        Veiculo veiculoSelecionado;
        public Veiculo VeiculoSelecionado
        {
            get
            {
                return veiculoSelecionado;
            }
            set
            {
                veiculoSelecionado = value;
                if(value != null)
                    MessagingCenter.Send(veiculoSelecionado, "VeiculoSelecionado");

                /*
                 * ------ MessagingCenter ------
                 Componente permite que componentes de uma aplicação Xamarin 
                 comuniquem-se uns com os outros 
                 através de mensagens 
                 sem necessariamente conhecerem uns aos outros
                 */
            }
        }

        private bool aguarde;

        public bool Aguarde
        {
            get { return aguarde; }
            set { aguarde = value; OnPropertyChanged(); }
        }

        public ListagemViewModel()
        {
            this.Veiculos = new ObservableCollection<Veiculo>();
        }

        public async Task GetVeiculos()
        {

            Aguarde = true;

            HttpClient client = new HttpClient();

            var result = await client.GetStringAsync(URL_GET_VEICULOS);
            var json = JsonConvert.DeserializeObject<clsVeiculo[]>(result);

            foreach (var item in json)
            {
                this.Veiculos.Add(new Veiculo
                {
                    Nome = item.nome,
                    Preco = item.preco
                });
            }

            Aguarde = false;
        }

        class clsVeiculo
        {
            public string nome { get; set; }
            public int preco { get; set; }
        }
    }
}
