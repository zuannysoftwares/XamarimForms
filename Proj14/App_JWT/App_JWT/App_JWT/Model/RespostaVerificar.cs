using System;
using System.Collections.Generic;
using System.Text;

namespace App_JWT.Model
{
    public class RespostaVerificar
    {
        public string JWT { get; set; }
        public Usuario usuario { get; set; }
    }
}
