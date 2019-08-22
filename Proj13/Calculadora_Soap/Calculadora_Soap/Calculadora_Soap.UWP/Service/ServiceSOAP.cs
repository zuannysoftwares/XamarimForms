using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: Xamarin.Forms.Dependency(typeof(Calculadora_Soap.UWP.Service.ServiceSOAP))]
namespace Calculadora_Soap.UWP.Service
{
    public class ServiceSOAP : IServiceSOAP
    {
        public string Somar(int n1, int n2)
        {
            var serv = new ServiçoWS.CalculatorSoapClient();
            var result = serv.AddAsync(n1, n2).GetAwaiter().GetResult();

            return "Resultado WS SOAP(IOS): " + result;
        }
    }
}
