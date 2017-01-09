using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;

namespace IsaB.BusinessObjects
{
    public class Modernisierung
    {
        public int ID { get; set; }
        public int MaxPunkte { get; set; }
        public string ModernElement { get; set; }
        private double _vergPunkte;
        /// <summary>
        /// Die tatsächlich vergebenen Punkte.
        /// </summary>
        public double VergPunkte
        {
            get { return _vergPunkte; }
            set
            {
                value = Math.Min(MaxPunkte, value);
                if (_vergPunkte != value)
                {
                    _vergPunkte = value;
                }
            }
        }
        /// <summary>
        /// Symbolisiert die Modernisierung
        /// </summary>
        public ImageSource Symbol { get; set; }
    }
}
