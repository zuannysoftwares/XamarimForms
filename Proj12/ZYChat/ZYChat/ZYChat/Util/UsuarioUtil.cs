using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using ZYChat.Model;

namespace ZYChat.Util
{
    public class UsuarioUtil
    {
        public static void SetUsuarioLogado(Usuario usuario)
        {
            App.Current.Properties["LOGIN"] = JsonConvert.SerializeObject(usuario);
        }
        public static Usuario GetUsuarioLogado()
        {
            if (App.Current.Properties.ContainsKey("LOGIN"))
            {
                return JsonConvert.DeserializeObject<Usuario>((string)App.Current.Properties["LOGIN"]);
            }
            else
            {
                return null;
            }
        }
    }
}
