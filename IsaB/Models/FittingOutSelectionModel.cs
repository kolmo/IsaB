using IsaB.Entities;
using Template10.Mvvm;

namespace IsaB.Models
{
    public class FittingOutSelectionModel : BindableBase
    {
        #region constructors
        public FittingOutSelectionModel(GebAusbauzustandEntity construction)
        {
            Entity = construction;
        }
        #endregion

        #region Properties
        public GebAusbauzustandEntity Entity { get; }
        private bool _isSelected;
        public bool IsSelected
        {
            get { return _isSelected; }
            set { Set(ref _isSelected, value); }
        }
        public string Description { get { return Entity.Bezeichnung; } }
        #endregion
    }
}
