using IsaB.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsaB.CommandStack.Commands
{
    public class SaveEstateAddressCommand : Command
    {
        public int EstateID { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Postcode { get; set; }

    }
}
