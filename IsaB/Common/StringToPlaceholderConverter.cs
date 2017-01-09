using System;
using Windows.UI.Xaml.Data;

namespace IsaB.Common
{
    /// <summary>
    /// Gibt den Parameter als Platzhalter zurück falls der String leer ist.
    /// </summary>
    public class StringToPlaceholderConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return value ?? parameter;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value;
        }
    }
}
