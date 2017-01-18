using System;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace IsaB.Common
{
    public class DoubleToSolidColorBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is double)
            {
                double dvalue = (double)value;
                double f = 2.55;
                byte rvalue = (byte)(255.0 - f * dvalue);
                byte gvalue = (byte)(f * dvalue);
                return new SolidColorBrush(new Windows.UI.Color() { A = 255, R = rvalue, G = gvalue, B = 0 });
            }
            else
                return new SolidColorBrush(new Windows.UI.Color() { A = 255, R = 255, G = 0, B = 0 });
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
