using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace CryptocurrencuiesApp.Converters
{
    [ValueConversion(typeof(double), typeof(string))]
    public class NumberToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double number = (double)value;
            if (number > 0)
            {
                return "Green";
            }
            else if(number < 0)
            {
                return "Red";
            }
            else
            {
                return "Black";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
