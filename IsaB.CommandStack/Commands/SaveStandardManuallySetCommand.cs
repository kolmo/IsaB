using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsaB.CommandStack.Commands
{
    public class SaveStandardManuallySetCommand:Infrastructure.Command
    {
        public int EstateId { get; set; }
        public double? StandardManuallySet { get; set; }
    }
}
