using IsaB.Entities;

namespace IsaB.CommandStack.Commands
{
    public class SavePartPropSettingCommand : Infrastructure.Command
    {
        public EstateStandardLevelPropertyEntity EstateStdLevelProp { get; set; }
    }
}
