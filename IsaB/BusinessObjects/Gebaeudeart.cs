using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;

namespace IsaB.BusinessObjects
{
    /// <summary>
    /// Repräsentiert die lokale Klasse für Gebäudeart
    /// </summary>
    public class Gebaeudeart
    {
        public int ID { get; set; }
        public string Bezeichnung { get; set; }
        public List<Immobilie> Immobilien { get; set; }
        public override string ToString()
        {
            return Bezeichnung;
        }
        public ImageSource Gruppenbild { get; set; }
        private bool _isSelected;
        /// <summary>
        /// Gets or sets the IsSelected.
        /// </summary>
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (_isSelected != value)
                {
                    _isSelected = value;
                }
            }
        }
    }
}
