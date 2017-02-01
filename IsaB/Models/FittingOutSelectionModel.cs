using IsaB.Entities;
using Template10.Mvvm;

namespace IsaB.Models
{
    public class FittingOutSelectionModel : ViewModels.EditViewModelBase
    {
        #region constructors
        public FittingOutSelectionModel(GebAusbauzustandEntity construction, bool isSelected)
        {
            Entity = construction;
            _isSelected = isSelected;
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
