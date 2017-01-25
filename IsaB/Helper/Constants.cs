using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsaB.Helper
{
    public static class Constants
    {
        public static Dictionary<int, Uri> DefaultImageSources = new Dictionary<int, Uri>();
        static Constants()
        {
            DefaultImageSources[3] = new Uri("ms-appx:///Assets/Square44x44Logo.png");
            DefaultImageSources[1] = new Uri("ms-appx:///Assets/ThumbUp.png");
            DefaultImageSources[2] = new Uri("ms-appx:///Assets/StoreLogo.png");
        }
    }
}
