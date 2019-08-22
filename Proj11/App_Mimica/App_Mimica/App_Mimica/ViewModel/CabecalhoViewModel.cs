using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App_Mimica.ViewModel
{
    public class CabecalhoViewModel
    {
        public Command ReiniciarJogo { get; set; }

        public CabecalhoViewModel()
        {
            ReiniciarJogo = new Command(Reiniciar);
        }

        private void Reiniciar()
        {
            App.Current.MainPage = new View.Inicio();
        }
    }
}
