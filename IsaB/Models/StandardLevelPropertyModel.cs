using IsaB.Entities;
using Template10.Mvvm;

namespace IsaB.Models
{
    public class StandardLevelPropertyModel : BindableBase
    {
        public StandardLevelPropertyModel(StandardLevelPropertyEntity e, EstateStandardLevelPropertyEntity exs)
        {
            Entity = e;
            EstateStandardLevelProp = exs;
            _isSelected = exs.IsSelected;
        }
        public StandardLevelPropertyEntity Entity { get; }
        public EstateStandardLevelPropertyEntity EstateStandardLevelProp { get; }
        private bool _isSelected;
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                EstateStandardLevelProp.IsSelected = value;
                Set(ref _isSelected, value);
            }
        }
        public string Property { get { return Entity.Beschreibung; } }
        public int Level { get { return Entity.Stufe; } }
    }

}
