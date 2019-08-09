using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using TestDrive.Models;
using Xamarin.Forms;

namespace TestDrive
{
    public class LoginService
    {
        public async System.Threading.Tasks.Task Logar(Login login)
        {
            using (var client = new HttpClient())
            {
                var camposForm = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("email", login.email),
                    new KeyValuePair<string, string>("senha", login.senha)
                });

                client.BaseAddress = new Uri("https://aluracar.herokuapp.com");
                HttpResponseMessage result = null;

                try
                {
                    result = await client.PostAsync("/login", camposForm);
                }
                catch (Exception)
                {
                    MessagingCenter.Send<LoginException>(new LoginException(@"Ocorreu um erro de comunicação com o servidor.
 Por favor, verifique sua conexão e tente novamente."), "FalhaLogin");
                }

                if (result.IsSuccessStatusCode)
                {
                    var contentResult = await result.Content.ReadAsStringAsync();
                    var loginResult = JsonConvert.DeserializeObject<LoginResult>(contentResult);
                    
                    MessagingCenter.Send<Usuario>(loginResult.usuario, "SucessoLogin");
                }
                else
                    MessagingCenter.Send<LoginException>(new LoginException("Usuário ou senha incorretos"), "FalhaLogin");
            }
        }
    }

    public class LoginException : Exception
    {
        public LoginException(string message) : base(message)
        {
        }
    }


}
