﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TipoPaginaXF.TipoPagina.Carousel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TipoPagina3 : ContentPage
    {
        public TipoPagina3()
        {
            InitializeComponent();
        }

        private void MudarPagina(object sender, EventArgs args)
        {
            //App.Current.MainPage = new NavigationPage(new Navigation.Page1()) { BarBackgroundColor = Color.LightBlue };
            App.Current.MainPage = new Tabbed.Abas();
        }
    }
}