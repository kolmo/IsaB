using IsaB.CommandStack.Commands;
using IsaB.Infrastructure;
using System.Linq;

namespace IsaB.CommandStack.Sagas
{
    public class SavePartPropSettingSaga : Saga, IAmStartedBy<SavePartPropSettingCommand>
    {
        public SavePartPropSettingSaga(IBus bus, IRepository repository) : base(bus, repository)
        {
        }

        public void Handle(SavePartPropSettingCommand message)
        {
            message?.EstateStdLevelProp?.ToList().ForEach(x => Repository.Save(x));
        }
    }
}
