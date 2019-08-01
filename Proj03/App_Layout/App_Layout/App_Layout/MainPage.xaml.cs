using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App_Layout
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void GoPaginaStack(object sender, EventArgs args)
        {
            Navigation.PushAsync(new Layout.Stack.StackPae());
        }
        private void GoPaginaGrid(object sender, EventArgs args)
        {
            Navigation.PushAsync(new Layout.Grid.GridPage());
        }
        private void GoPaginaAbsolute(object sender, EventArgs args)
        {
            Navigation.PushAsync(new Layout.Absolute.AbsolutePage());
        }
        private void GoPaginaRelative(object sender, EventArgs args)
        {
            Navigation.PushAsync(new Layout.Relative.RelativePage());
        }
        private void GoPaginaScroll(object sender, EventArgs args)
        {
            Navigation.PushAsync(new Layout.Scroll.ScrollPage());
        }
    }
}
