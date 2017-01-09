namespace IsaB.Model
{
    public abstract class GebaeudeBaseModel : BaseModel
    {
        #region Fields
        private bool _isSelected;
        #endregion
        public string Bezeichnung { get; protected set; }
        public int ID { get; protected set; }
        /// <summary>
        /// Gets or sets the IsSelected.
        /// </summary>
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                Set(ref _isSelected, value);
            }
        }
    }
}
