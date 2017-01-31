using IsaB.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IsaB.CommandStack.Commands;

namespace IsaB.CommandStack.Sagas
{
    public class SaveEstateFittingOutSaga : Saga, IAmStartedBy<SaveEstateFittingOutCommand>
    {
        public SaveEstateFittingOutSaga(IBus bus, IRepository repository) : base(bus, repository)
        {
        }

        public void Handle(SaveEstateFittingOutCommand message)
        {
            if (message != null)
            {
                var estate = Repository.GetById<Entities.ImmobilieEntity>(message.EstateId);
                if (estate.AusbauzustandId != message.FittingOutId)
                {
                    estate.AusbauzustandId = message.FittingOutId;
                    Repository.Save(estate);
                }
            }
        }
    }
}
