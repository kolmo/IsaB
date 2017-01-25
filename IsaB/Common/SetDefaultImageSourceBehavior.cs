using Microsoft.Xaml.Interactivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace IsaB.Common
{
    public class SetDefaultImageSourceBehavior
    {
        public static int GetDefaultSource(DependencyObject obj)
        {
            return (int)obj.GetValue(DefaultSourceProperty);
        }

        public static void SetDefaultSource(DependencyObject obj, int value)
        {
            obj.SetValue(DefaultSourceProperty, value);
        }

        // Using a DependencyProperty as the backing store for DefaultSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DefaultSourceProperty =
            DependencyProperty.RegisterAttached("DefaultSource", typeof(int), typeof(SetDefaultImageSourceBehavior), new PropertyMetadata(null));

    }
}
