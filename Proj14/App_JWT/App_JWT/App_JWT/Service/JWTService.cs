using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using App_JWT.Model;

namespace App_JWT.Service
{
    public class JWTService
    {
        private static string BaseURL = "http://ws.spacedu.com.br/xf2018/apix";
        private static string Token;
        private static string TokenType;

        public async static Task<string> GetToken(string nome, string senha)
        {
            var URL = BaseURL + "/token";
            HttpClient request = new HttpClient();

            var parametros = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>("nome", nome),
                new KeyValuePair<string, string>("password", senha)
            });

            var response = await request.PostAsync(URL, parametros);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responseToken = JsonConvert.DeserializeObject<RespostaToken>(response.Content.ReadAsStringAsync().GetAwaiter().GetResult());
                Token = responseToken.access_token;
                TokenType = responseToken.token_type;

                return Token;
            }
            else
            {
                return response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            }
        }

        public async static Task<string> Verificar()
        {
            var URL = BaseURL + "/verify";

            HttpClient request = new HttpClient();

            request.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(TokenType, Token);

            var response = await request.GetAsync(URL);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responseToken = JsonConvert.DeserializeObject<RespostaVerificar>(response.Content.ReadAsStringAsync().GetAwaiter().GetResult());
                return responseToken.usuario.nome + " - " + responseToken.usuario.id;
            }
            else
            {
                return response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            }
        }
    }
}
