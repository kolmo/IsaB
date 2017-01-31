using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsaB.Entities
{
    [SQLite.Table("StandardTable")]
    public class StandardTableEntity : Base.Entity
    {
        public string Description { get; set; }
        public double MinimumLevel { get; set; }
        public double MaximumLevel { get; set; }
    }
}
