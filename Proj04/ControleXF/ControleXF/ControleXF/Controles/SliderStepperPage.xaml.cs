using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ControleXF.Controles
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SliderStepperPage : ContentPage
	{
		public SliderStepperPage ()
		{
			InitializeComponent ();
		}

        private void MudaValor(object sender, ValueChangedEventArgs args)
        {
            SliderResult.Text = args.NewValue.ToString();
        }

        private void MudaValorStepper(object sender, ValueChangedEventArgs args)
        {
            StepperResult.Text = args.NewValue.ToString();
        }
    }
}