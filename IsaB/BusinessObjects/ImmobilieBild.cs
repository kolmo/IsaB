using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;

namespace IsaB.BusinessObjects
{
    public class ImmobilieBild
    {
        public int Id { get; set; }
        public ImageSource Bild { get; set; }
        public int ImmobilieId { get; set; }
        public byte[] Bilddaten { get; set; }
        public string Beschriftung { get; set; }
        public DateTime? SetAsTitlePictureDate { get; set; }
        public bool IsTitlePic { get; set; }
        public DateTime Created { get; set; }
    }
}
