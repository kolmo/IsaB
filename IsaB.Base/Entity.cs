namespace IsaB.Base
{
    public class Entity
    {
        [SQLite.PrimaryKey]
        [SQLite.AutoIncrement]
        public int ID { get; set; }
    }
}
