﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App_Estilo.Menu
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Master : MasterDetailPage
	{
		public Master ()
		{
			InitializeComponent ();
		}

        private void GoPagina1(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new Paginas.ImplicitStylePage());
            IsPresented = false;
        }

        private void GoPagina2(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new Paginas.ExplicitStylePage());
            IsPresented = false;
        }

        private void GoPagina3(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new Paginas.GlobalStylePage());
            IsPresented = false;
        }

        private void GoPagina4(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new Paginas.HerancaStylePage());
            IsPresented = false;
        }

        private void GoPagina5(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new Paginas.DynamicStylePage());
            IsPresented = false;
        }

    }
}