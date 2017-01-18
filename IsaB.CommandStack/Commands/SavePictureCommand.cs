using IsaB.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsaB.CommandStack.Commands
{
    public class SavePictureCommand : Command
    {
        public int EstateId { get; set; }
        public byte[] PictureData { get; set; }
    }
}
