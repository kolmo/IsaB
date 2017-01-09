using IsaB.Common;
using IsaB.Interfaces;
using IsaB.BusinessObjects;
using System;

namespace IsaB.Model
{
    public class BildModel : BaseModel
    {
        #region Fields
        ImmobilieBild _immobild;
        #endregion
        #region Constructor
        public BildModel(ImmobilieBild immobild)
        {
            _immobild = immobild;
        }
        #endregion
        public ImmobilieBild Bild { get { return _immobild; } }
        public int Id { get { return _immobild.Id; } }
        public int ImmobilieId { get { return _immobild.ImmobilieId; } }
        public byte[] Bilddaten
        {
            get { return _immobild.Bilddaten; }
            set
            {
                if (_immobild.Bilddaten != value)
                {
                    _immobild.Bilddaten = value;
                    Repository.SaveBild(_immobild);
                }
            }
        }
        public string Beschriftung { get { return _immobild.Beschriftung; } }

        /// <summary>
        /// Gets or sets the SetAsTitlePic.
        /// </summary>
        public bool IsTitlePic
        {
            get { return _immobild.IsTitlePic; }
            set
            {
                if (_immobild.IsTitlePic != value)
                {
                    _immobild.IsTitlePic = value;
                }
            }
        }

    }
}
