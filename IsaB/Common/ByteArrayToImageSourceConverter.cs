using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media.Imaging;

namespace IsaB.Common
{
    /// <summary>
    /// Konvertiert ein Byte-Array zu einer ImageSource
    /// </summary>
    public class ByteArrayToImageSourceConverter : IValueConverter
    {
        public string DefaultImageResourcePath { get; set; }
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is byte[])
            {
                using (InMemoryRandomAccessStream ms = new InMemoryRandomAccessStream())
                {
                    using (DataWriter writer = new DataWriter(ms.GetOutputStreamAt(0)))
                    {
                        writer.WriteBytes((byte[])value);
                        writer.StoreAsync().GetResults();
                    }

                    var bitmapImage = new BitmapImage();
                    bitmapImage.SetSource(ms);
                    return bitmapImage;
                }
            }
            else if (value is BitmapImage)
                return value;
            else if (value is string)
                return new BitmapImage(new Uri((string)value));
            else if (value is Uri)
                return new BitmapImage(value as Uri);
            else
                return DefaultImageResourcePath;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
