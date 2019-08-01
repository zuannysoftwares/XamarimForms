using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using ConsultarCEP.Servico.Modelo;
using Newtonsoft.Json;

namespace ConsultarCEP.Servico
{
    public class viaCEPServico
    {
        private static string EnderecoURL = "http://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscarEnderecoViaCEP(string cep)
        {
            string NovoEnderecoURL = string.Format(EnderecoURL, cep);

            WebClient wc = new WebClient();
            string result = wc.DownloadString(NovoEnderecoURL);

            Endereco end = JsonConvert.DeserializeObject<Endereco>(result) ;

            if (end.cep == null)
            {
                return null;
            }

            return end;

        }
    }
}
