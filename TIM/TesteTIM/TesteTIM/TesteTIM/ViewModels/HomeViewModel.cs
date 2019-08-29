using System;
using System.Collections.Generic;
using System.Text;
using TesteTIM.Models;

namespace TesteTIM.ViewModels
{
    public class HomeViewModel
    {
        public IList<HomeModel> lstHome { get; set; }
        public object SelectedItem { get; set; }

        public HomeViewModel()
        {
            lstHome = new List<HomeModel>();
            GerarCardModel();
        }

        private void GerarCardModel()
        {
            string[] arrFuncionalidades = { "LEADS", "PROPOSTAS", "CONTRATOS" };

            Random ran = new Random();

            for (var i = 0; i < arrFuncionalidades.Length; i++)
            {
                var qtd = ran.Next(5, 20);
                var func = new HomeModel()
                {
                    Nome = arrFuncionalidades[i],
                    Quantidade = qtd,
                };

                lstHome.Add(func);
            }
        }
    }
}
