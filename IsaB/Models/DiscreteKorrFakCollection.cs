using IsaB.BusinessObjects;
using IsaB.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsaB.Model
{
    public class DiscreteKorrFakCollection : KorrFakCollectionBase
    {
        #region Props

        #endregion
        public DiscreteKorrFakCollection()
        {
        }
        public DiscreteKorrFakCollection(Korrekturfaktortyp typ,
            IEnumerable<Korrekturfaktor> list)
            : base(typ, list)
        {
            Init();
        }
        private void Init()
        {
            if (this.KorrFaktorListe!= null)
            {
                foreach (KorrekturfaktorModel item in KorrFaktorListe)
                {
                    item.PropertyChanged += item_PropertyChanged;
                }
            }
        }

        void item_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            KorrekturfaktorModel faktor = sender as KorrekturfaktorModel;
            if (faktor!= null && faktor.IsSelected)
            {
                Faktorwert = faktor.Faktor;
                SelectedFaktorName = faktor.Beschreibung;
            }
        }

        public override void SetFaktorWert(ImmobilieKorrekturfaktor wert)
        {
            Faktorwert = wert.Faktor;
            foreach (KorrekturfaktorModel item in KorrFaktorListe)
            {
                if (item.Faktor == wert.Faktor)
                {
                    item.IsSelected = true;
                }
            }
        }
    }
}
