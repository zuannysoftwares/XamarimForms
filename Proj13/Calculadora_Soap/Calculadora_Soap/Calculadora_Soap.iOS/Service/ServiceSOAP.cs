using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(Calculadora_Soap.iOS.Service.ServiceSOAP))]
namespace Calculadora_Soap.iOS.Service
{
    public class ServiceSOAP : IServiceSOAP
    {
        public string Somar(int n1, int n2)
        {
            var serv = new com.dneonline.www.Calculator();
            var result = serv.Add(n1, n2);

            return "Resultado WS SOAP(IOS): " + result;
        }
    }
}