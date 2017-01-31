using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IsaB.Infrastructure;
using IsaB.CommandStack.Commands;

namespace IsaB.CommandStack.Sagas
{
    public class SaveModernizationSaga : Saga, IAmStartedBy<SaveModernizationCommand>
    {
        public SaveModernizationSaga(IBus bus, IRepository repository) : base(bus, repository)
        {
        }

        public void Handle(SaveModernizationCommand message)
        {
            if (message!= null)
            {
                Repository.Save(message.EstateModernization);
            }
        }
    }
}
