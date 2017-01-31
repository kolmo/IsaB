using IsaB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace IsaB.Common
{
    public class ModernizationPointsToRotationAngleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var modernization = value as Tuple<double, double?>;
            if (modernization!= null && modernization.Item2.HasValue)
            {
                double deltaAngle = 180.0d /modernization.Item1;
                double rotationAngle = 180.0d - deltaAngle * modernization.Item2.Value;
                return rotationAngle;
            }
            else
            {
                return 0;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
