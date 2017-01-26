using IsaB.Helper;
using System;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media.Imaging;

namespace IsaB.Common
{
    class BuildingKindToImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is int)
            {
                if (Constants.DefaultImageSourceUris.ContainsKey((int)value))
                {
                    return new BitmapImage(Constants.DefaultImageSourceUris[(int)value]);
                }
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
