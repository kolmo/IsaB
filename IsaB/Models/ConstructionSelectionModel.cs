using IsaB.Entities;
using Template10.Mvvm;

namespace IsaB.Models
{
    public class ConstructionSelectionModel : ViewModels.EditViewModelBase
    {
        #region constructors
        public ConstructionSelectionModel(GebBauweiseEntity construction, bool isSelected)
        {
            Entity = construction;
            _isSelected = isSelected;
        }
        #endregion

        #region Properties
        public GebBauweiseEntity Entity { get; }
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
