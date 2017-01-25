using System;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace IsaB.Common
{
    public class Int2SolidColorBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is int)
            {
                int dvalue = (int)value;
                int step = 51;
                byte a = (byte)(step*(dvalue - 1));
                return new SolidColorBrush(new Windows.UI.Color() { A = a, R = 0, G = 255, B = 0 });

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
