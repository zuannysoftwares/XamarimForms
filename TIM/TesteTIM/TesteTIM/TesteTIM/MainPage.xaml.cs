using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteTIM.ViewModels;
using TesteTIM.Views;
using Xamarin.Forms;

namespace TesteTIM
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            this.BindingContext = new HomeViewModel();
        }

        public void MainPageCommand(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new MainPage());
        }

        public void TarefasCommand(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new Tarefas());
        }

        private void PerfilCommand(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Perfil());
        }
    }
}
