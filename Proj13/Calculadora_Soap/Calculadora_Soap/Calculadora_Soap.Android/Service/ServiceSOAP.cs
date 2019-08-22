using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

[assembly:Xamarin.Forms.Dependency(typeof(Calculadora_Soap.Droid.Service.ServiceSOAP))]
namespace Calculadora_Soap.Droid.Service
{
    public class ServiceSOAP : IServiceSOAP
    {
        public string Somar(int n1, int n2)
        {
            var serv = new com.dneonline.www.Calculator();
            var result = serv.Add(n1,n2);

            return "Resultado WS SOAP(DROID): " + result;
        }
    }
}