﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Http;
using ZYChat.Model;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace ZYChat.Service
{
    public class ServiceWS
    {
        private static string EnderecoBase = "http://ws.spacedu.com.br/xf2018/rest/api";
        public async static Task<Usuario> GetUsuario(Usuario usuario)
        {
            var URL = EnderecoBase + "/usuario";

            //StringContent param = new StringContent(string.Format("nome={0}&password={1}", usuario.nome, usuario.password));

            FormUrlEncodedContent param = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>("nome", usuario.nome),
                new KeyValuePair<string, string>("password", usuario.password)
            });

            HttpClient request = new HttpClient();

            HttpResponseMessage response = await request.PostAsync(URL, param);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Usuario>(content);
            }

            return null;
        }

        public async static Task<List<Chat>> GetChats()
        {
            var url = EnderecoBase + "/chats";

            HttpClient request = new HttpClient();
            HttpResponseMessage response = await request.GetAsync(url);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                string content = await response.Content.ReadAsStringAsync();

                if (content.Length > 2)
                {
                    List<Chat> lista = JsonConvert.DeserializeObject<List<Chat>>(content);
                    return lista;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                throw new Exception("Erro: " + response.StatusCode);
            }
        }

        public async static Task<bool> InsertChat(Chat chat)
        {
            var url = EnderecoBase + "/chat";

            FormUrlEncodedContent param = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>("nome", chat.nome)
            });

            HttpClient request = new HttpClient();

            HttpResponseMessage response = await request.PostAsync(url, param);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }

            return false;
        }

        public static bool RenomearChat(Chat chat)
        {
            var url = EnderecoBase + "/chat/" + chat.id;

            FormUrlEncodedContent param = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>("nome", chat.nome)
            });

            HttpClient request = new HttpClient();

            HttpResponseMessage response = request.PutAsync(url, param).GetAwaiter().GetResult();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }

            return false;
        }

        public static bool DeleteChat(Chat chat)
        {
            var url = EnderecoBase + "/chat/delete/" + chat.id;

            HttpClient request = new HttpClient();
            HttpResponseMessage response = request.DeleteAsync(url).GetAwaiter().GetResult();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }

            return false;
        }

        public async static Task<List<Mensagem>> GetMensagensChat(Chat chat)
        {
            var url = EnderecoBase + "/chat/" + chat.id + "/msg";

            HttpClient request = new HttpClient();
            HttpResponseMessage response = await request.GetAsync(url);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                string content = await response.Content.ReadAsStringAsync();

                if (content.Length > 2)
                {
                    List<Mensagem> lista = JsonConvert.DeserializeObject<List<Mensagem>>(content);
                    return lista;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                throw new Exception("Erro: " + response.StatusCode);
            }
        }

        public static bool InsertMensagem(Mensagem mensagem)
        {
            var url = EnderecoBase + "/chat/" + mensagem.id_chat + "/msg";

            FormUrlEncodedContent param = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>("mensagem", mensagem.mensagem),
                new KeyValuePair<string, string>("id_usuario", mensagem.id_usuario.ToString())
            });

            HttpClient request = new HttpClient();

            HttpResponseMessage response = request.PostAsync(url, param).GetAwaiter().GetResult();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }

            return false;
        }

        public static bool DeleteMensagem(Mensagem mensagem)
        {
            var url = EnderecoBase + "/chat/" + mensagem.id_chat + "/delete/" + mensagem.id;

            HttpClient request = new HttpClient();
            HttpResponseMessage response = request.DeleteAsync(url).GetAwaiter().GetResult();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }

            return false;
        }
    }
}
