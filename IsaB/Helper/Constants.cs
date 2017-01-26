using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsaB.Helper
{
    public static class Constants
    {
        public static Dictionary<int, Uri> DefaultImageSourceUris = new Dictionary<int, Uri>();
        static Constants()
        {
            DefaultImageSourceUris[1] = new Uri("ms-appx:///Assets/casa0069.png");
            DefaultImageSourceUris[2] = new Uri("ms-appx:///Assets/casa0069.png");
            DefaultImageSourceUris[3] = new Uri("ms-appx:///Assets/casa0069.png");
            DefaultImageSourceUris[4] = new Uri("ms-appx:///Assets/casa0069.png");
        }
    }
}
