using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace IsaB.Common
{
    public class IntegerToDateTimeOffsetConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is int)
            {
                int year = (int)value;
                return new DateTimeOffset(year, 1, 1, 0, 0, 0, TimeSpan.Zero);
            }
            else
                return DateTimeOffset.Now;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value is DateTimeOffset)
                return ((DateTimeOffset)value).Year;
            else
                return null;
        }
    }
}
