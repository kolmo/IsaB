using IsaB.Common;
using IsaB.Interfaces;
using IsaB.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;

namespace IsaB.Model
{
    public class ModernisierungModel : BaseModel
    {
        #region Fields
        ImmobilieModernisierung _immoModernisierung;
        Modernisierung _modernisierung;
        #endregion

        #region Props
        public int ID { get { return _modernisierung.ID; } }
        public int MaxPunkte { get { return _modernisierung.MaxPunkte; }
            set
            {
                if (_modernisierung.MaxPunkte!=value)
                {
                    _modernisierung.MaxPunkte = value;
                }
            }
        }
        public string ModernElement { get { return _modernisierung.ModernElement; } }
        /// <summary>
        /// Die tatsächlich vergebenen Punkte.
        /// </summary>
        public int VergPunkte
        {
            get { return _immoModernisierung!= null ? (int)_immoModernisierung.Punkte : 0; }
            set
            {
                if (_immoModernisierung != null)
                {
                    value = Math.Min(MaxPunkte, value);
                    if (_immoModernisierung.Punkte != value)
                    {
                        _immoModernisierung.Punkte = value;
                        Repository.SaveModernisierung(_immoModernisierung);
                    }
                }
            }
        }
        /// <summary>
        /// Symbolisiert die Modernisierung
        /// </summary>
        public ImageSource Symbol { get; set; }
        #endregion

        #region Construction
        public ModernisierungModel(Modernisierung modernisierung, ImmobilieModernisierung immoModern)
        {
            _immoModernisierung = immoModern;
            _modernisierung = modernisierung;
        }
        #endregion
    }
}
