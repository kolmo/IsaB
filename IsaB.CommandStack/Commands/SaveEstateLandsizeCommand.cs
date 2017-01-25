using IsaB.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsaB.CommandStack.Commands
{
    public class SaveEstateLandsizeCommand : Command
    {
        public int EstateID { get; set; }
        public float? Landsize { get; set; }
        public float? StandardGroundValue { get; set; }
        public float? LivingSpace { get; set; }
    }
}
