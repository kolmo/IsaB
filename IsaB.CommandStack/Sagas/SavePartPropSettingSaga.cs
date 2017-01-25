using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IsaB.CommandStack.Commands;
using IsaB.Infrastructure;
using IsaB.Entities;

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
