using System;
using System.Collections.Generic;
using System.Text;
using App_Mimica.Model;

namespace App_Mimica.Armazenamento
{
    public class Armazenamento
    {
        public static JogoModel Jogo { get; set; }
        public static short RodadaAtual { get; set; }

        public static string[][] Palavras =
        {
            new string[] { "Olho", "Língua", "Tênis", "Rosa", "Gol", "Carro" },
            new string[] { "Carteiro", "Motorista", "Celular", "Cachoeira" },
            new string[] { "Programador", "Igreja", "Casamento", "Velozes e Furiosos", "Kobe Bryant" },
        };

    }
}
