using IsaB.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsaB.Entities
{
    public class Entity : IEntity
    {
        [SQLite.PrimaryKey]
        [SQLite.AutoIncrement]
        public int ID { get; set; }
    }
}
