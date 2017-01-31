using IsaB.CommandStack.Commands;
using IsaB.Infrastructure;

namespace IsaB.CommandStack.Sagas
{
    public class SavePartPropSettingSaga : Saga, IAmStartedBy<SavePartPropSettingCommand>
    {
        public SavePartPropSettingSaga(IBus bus, IRepository repository) : base(bus, repository)
        {
        }

        public void Handle(SavePartPropSettingCommand message)
        {
            if (message!= null)
            {
                Repository.Save(message.EstateStdLevelProp);
            }
        }
    }
}
