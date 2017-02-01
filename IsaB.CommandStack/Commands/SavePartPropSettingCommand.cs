using IsaB.Entities;
using System.Collections.Generic;

namespace IsaB.CommandStack.Commands
{
    public class SavePartPropSettingCommand : Infrastructure.Command
    {
        public IList<EstateStandardLevelPropertyEntity> EstateStdLevelProp { get; set; }
    }
}
