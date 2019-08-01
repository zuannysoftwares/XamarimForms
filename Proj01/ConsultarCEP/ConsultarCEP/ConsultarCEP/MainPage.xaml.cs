using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ConsultarCEP.Servico.Modelo;
using ConsultarCEP.Servico;

namespace ConsultarCEP
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            btnBusca.Clicked += BuscarCEP; 
        }

        private void BuscarCEP(object sender, EventArgs args)
        {
            string cep = txtCep.Text.Trim();

            if (isValidCEP(cep))
            {
                try
                {
                    Endereco end = viaCEPServico.BuscarEnderecoViaCEP(cep);
                    if(end != null)
                        lblResult.Text = string.Format("Endereço: {2}, Cidade -> {0}-{1}", end.localidade, end.uf, end.logradouro);
                    else
                        DisplayAlert("Erro", "O endereço para o CEP: " + cep + ", não foi encontrado.", "OK");
                }
                catch (Exception e)
                {
                    DisplayAlert("Erro crítico ", e.Message, "OK");
                }
                
            }
        }

        private bool isValidCEP(string cep)
        {
            bool isValid = true;
            int novoCEP = 0;

            if(cep.Length != 8)
            {
                DisplayAlert("Erro", "O CEP deve conter 8 números.", "OK");
                isValid = false;
            }

            if (!int.TryParse(cep, out novoCEP))
            {
                DisplayAlert("Erro", "CEP Inválido! Digite apenas números.", "OK");
                isValid = false;
            }

            return isValid;
        }
    }
}
