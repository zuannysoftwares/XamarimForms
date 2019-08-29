using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace TIM_Jonata.Helpers
{
    public class Mascaras
    {
        public static string CpfCnpj(string cpfCnpj)
        {
            string texto = Regex.Replace(cpfCnpj, @"[^0-9]", string.Empty);

            if (texto.Length <= 11) // CPF
            {
                texto = texto.PadRight(9, '_');
                texto = texto.Insert(3, ".");
                texto = texto.Insert(7, ".");
                texto = texto.Insert(11, "-");
                texto = texto.TrimEnd('_', '-', '.', '_');
            }
            else // CNPJ
            {
                texto = texto.PadRight(9, '_');
                texto = texto.Insert(2, ".");
                texto = texto.Insert(6, ".");
                texto = texto.Insert(10, "/");
                texto = texto.Insert(15, "-");
                texto = texto.TrimEnd('_', '-', '.', '/', '_');
            }

            if (texto.Length > 18)
            {
                texto = texto.Substring(0, 18);
            }

            return texto;
        }
    }
}
