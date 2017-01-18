using IsaB.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsaB.CommandStack.Commands
{
    public class CreateNewEstateCommand : Command
    {
        public string NewStreet { get; set; }
        public string NewCity { get; set; }
        public int BuildingKind { get; set; }
    }
}
