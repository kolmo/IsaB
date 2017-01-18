using System;
using Windows.UI.Xaml.Data;

namespace IsaB.Common
{
    class FloatToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return value != null ? value.ToString() : null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            float? result = null;
            if (value != null)
            {
                float dec;
                if (float.TryParse(value.ToString(), out dec))
                {
                    result = dec;
                }
            }
            return result;
        }
    }
    class DoubleToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return value != null ? value.ToString() : null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            double? result = null;
            if (value != null)
            {
                double dec;
                if (double.TryParse(value.ToString(), out dec))
                {
                    result = dec;
                }
            }
            return result;
        }
    }
}
