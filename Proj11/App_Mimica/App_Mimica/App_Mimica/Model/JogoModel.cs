using System;
using System.Collections.Generic;
using System.Text;

namespace App_Mimica.Model
{
    public class JogoModel
    {
        public GrupoModel Grupo1 { get; set; }
        public GrupoModel Grupo2 { get; set; }
        public string Nivel { get; set; }
        public short Tempo { get; set; }
        public short Rodadas { get; set; }
        public int NivelNumerico { get; set; }
    }
}
