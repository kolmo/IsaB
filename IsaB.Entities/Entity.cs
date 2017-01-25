﻿using IsaB.Infrastructure;

namespace IsaB.Entities
{
    public class Entity : IEntity
    {
        [SQLite.PrimaryKey]
        [SQLite.AutoIncrement]
        public int ID { get; set; }
    }
}
