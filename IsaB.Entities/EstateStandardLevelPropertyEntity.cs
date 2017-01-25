namespace IsaB.Entities
{
    [SQLite.Table("EstateStandardLevelProperty")]
    public class EstateStandardLevelPropertyEntity : Base.Entity
    {
        public int EstateId { get; set; }
        public int StandardLevelPropertyId { get; set; }
        public bool IsSelected { get; set; }
    }
}
