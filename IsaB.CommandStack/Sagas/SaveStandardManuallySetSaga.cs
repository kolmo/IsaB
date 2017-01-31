using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IsaB.Infrastructure;
using IsaB.CommandStack.Commands;

namespace IsaB.CommandStack.Sagas
{
    public class SaveStandardManuallySetSaga : Infrastructure.Saga, IAmStartedBy<SaveStandardManuallySetCommand>
    {
        public SaveStandardManuallySetSaga(IBus bus, IRepository repository) : base(bus, repository)
        {
        }

        public void Handle(SaveStandardManuallySetCommand message)
        {
            if (message!= null)
            {
                var estate = Repository.GetById<Entities.ImmobilieEntity>(message.EstateId);
                if (estate.StandardManuallySet!= message.EstateId)
                {
                    estate.StandardManuallySet = message.StandardManuallySet;
                    Repository.Save(estate);
                }
            }
        }
    }
}
