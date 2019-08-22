using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Calculadora_Soap
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        public void EnviarSOAP(object sender, EventArgs args)
        {
            var num1 = int.Parse( Num1.Text);
            var num2 = int.Parse( Num2.Text);

            TxtResultado.Text = DependencyService.Get<IServiceSOAP>().Somar(num1, num2);
        }
    }
}
