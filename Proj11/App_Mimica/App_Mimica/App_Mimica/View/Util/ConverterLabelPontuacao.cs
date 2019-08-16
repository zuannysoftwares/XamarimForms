using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace App_Mimica.View.Util
{
    public class ConverterLabelPontuacao : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {//Da View pra ViewModel
            if ((byte)value == 0)
            {

                return "Palavra";
            }
            else
            {

                return "Pontuação: " + value + " pontos";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {//Da ViewModel pra View
            throw new NotImplementedException();
        }
    }
}
