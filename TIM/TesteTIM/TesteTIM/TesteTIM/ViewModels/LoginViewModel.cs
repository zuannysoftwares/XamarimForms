using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TesteTIM.ViewModels
{
    public class LoginViewModel
    {
        private void LogarCommand(object sender, EventArgs args)
        {
            Application.Current.MainPage = new NavigationPage(new MainPage());
        }
    }
}
