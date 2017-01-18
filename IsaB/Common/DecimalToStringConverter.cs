using System;
using Windows.Globalization.NumberFormatting;
using Windows.UI.Xaml.Data;

namespace IsaB.Common
{
    public class DecimalToStringConverter : IValueConverter
    {

        public int FractionDigits { get; set; }
        public string Unit { get; set; }
        public DecimalToStringConverter()
        {
            FractionDigits = 2;
        }
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
                return parameter?.ToString();
            string retval = string.Empty;
            DecimalFormatter df = new DecimalFormatter();
            SignificantDigitsNumberRounder inr = new SignificantDigitsNumberRounder();
            inr.SignificantDigits = 3;
            df.FractionDigits = FractionDigits;
            df.SignificantDigits = FractionDigits;
            if (value is decimal)
            {
                decimal decval = (decimal)value;
                retval = df.Format(inr.RoundDouble((double)decval));
            }
            else if (value is double)
            {
                retval = df.Format(inr.RoundDouble((double)value));
            }
            else if (value is float)
            {
                float floatVal = (float)value;
                retval = df.Format(inr.RoundDouble((double)floatVal));
            }
            else if (value is int)
            {
                int intval = (int)value;
                retval = df.Format(inr.RoundDouble((double)intval));
            }
            return $"{retval} {Unit}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {

            decimal? result = null;
            if (value != null)
            {
                decimal dec;
                if (decimal.TryParse(value.ToString(), out dec))
                {
                    result = dec;
                }
            }
            return result;
        }
    }
}
