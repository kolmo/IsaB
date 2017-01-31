using IsaB.Entities;
using Template10.Mvvm;

namespace IsaB.Models
{
    public class ModernizationModel : BindableBase
    {
        #region Constructor
        public ModernizationModel()
        {
        }
        #endregion

        #region Properties
        public int EstateId { get; set; }
        public int ModernElementId { get; set; }
        public string Description { get; set; }
        public int MaximumPoints { get; set; }
        private double? _pointsSet;
        /// <summary>
        /// Die gesetzten Punkte
        /// </summary>
        public double? PointsSet
        {
            get { return _pointsSet; }
            set { Set(ref _pointsSet, value); }
        }
        #endregion
    }
}
