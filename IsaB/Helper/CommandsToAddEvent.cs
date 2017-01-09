using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsaB.Helper
{
    public class CommandsToAddEvent : PubSubEvent<List<CommandWrapper>>
    {
    }
}
