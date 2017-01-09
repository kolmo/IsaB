using IsaB.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;

namespace IsaB.Model
{
    public class ImmobilienGruppeModel
    {
        #region Fields
        Gebaeudeart _gebaeudeart;
        #endregion

        #region Props
        public string Bezeichnung { get { return _gebaeudeart.Bezeichnung; } }
        public int ID { get { return _gebaeudeart.ID; } }
        #endregion
        public ImmobilienGruppeModel(Gebaeudeart gebaeudeart)
        {
            _gebaeudeart = gebaeudeart;
            Immobilien = new ObservableCollection<ImmobilieModel>();
        }
        public ObservableCollection<ImmobilieModel> Immobilien { get; private set; }
    }
}
