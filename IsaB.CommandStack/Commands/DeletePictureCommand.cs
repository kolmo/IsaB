using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsaB.CommandStack.Commands
{
    public class DeletePictureCommand : Infrastructure.Command
    {
        public int PictureID { get; set; }
    }
}
