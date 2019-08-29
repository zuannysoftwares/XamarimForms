using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteTIM.ViewModels;
using Xamarin.Forms;

namespace TesteTIM
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = new HomeViewModel();
        }
    }
}
