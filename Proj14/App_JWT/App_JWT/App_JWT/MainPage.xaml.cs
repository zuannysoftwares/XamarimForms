using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App_JWT.Model;
using App_JWT.Service;

namespace App_JWT
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public async void GetTokenAction(object sender, EventArgs args)
        {
            string response = await JWTService.GetToken(nome.Text, password.Text);
            LblResultado.Text = response;
        }
        public async void VerificarAction(object sender, EventArgs args)
        {
            string response = await JWTService.Verificar();
            LblResultado.Text = response;
        }
    }
}
