using ListaMunicipios.Modelo;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace ListaMunicipios.Servico
{
    public class Service
    {
        private static string API_ESTADO = "https://servicodados.ibge.gov.br/api/v1/localidades/estados";
        private static string API_MUNICIPIO = "https://servicodados.ibge.gov.br/api/v1/localidades/estados/{0}/municipios";

        public static List<Estado> GetEstados()
        {
            WebClient wc = new WebClient();
            string content = wc.DownloadString(API_ESTADO);

            return JsonConvert.DeserializeObject<List<Estado>>(content);
        }

        public static List<Municipio> GetMunicipios(int id_estado)
        {
            WebClient wc = new WebClient();
            string content = wc.DownloadString(string.Format(API_MUNICIPIO, id_estado));

            return JsonConvert.DeserializeObject<List<Municipio>>(content);
        }
    }
}
