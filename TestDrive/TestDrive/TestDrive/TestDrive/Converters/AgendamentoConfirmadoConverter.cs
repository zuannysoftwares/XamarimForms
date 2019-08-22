using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace TestDrive.Converters
{
    public class AgendamentoConfirmadoConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var confirmado = (bool)value;

            if (confirmado)
                return Color.GreenYellow;
            else
                return Color.Red;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var confirmado = (bool)value;

            if (confirmado)
                return Color.GreenYellow;
            else
                return Color.Red;
        }
    }
}
