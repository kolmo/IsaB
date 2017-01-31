using IsaB.CommandStack.Commands;
using IsaB.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsaB.CommandStack.Sagas
{
    public class SaveEstateConstructionSaga : Saga, IAmStartedBy<SaveEstateConstructionCommand>
    {
        #region Constructors
        public SaveEstateConstructionSaga(IBus bus, IRepository repository) : base(bus, repository)
        {
        }
        #endregion

        #region Interface members
        public void Handle(SaveEstateConstructionCommand message)
        {
            if (message!=null)
            {
                var estate = Repository.GetById<Entities.ImmobilieEntity>(message.EstateId);
                if (estate.BauweiseId!= message.ConstructionId)
                {
                    estate.BauweiseId = message.ConstructionId;
                    Repository.Save(estate);
                }
            }
        }
        #endregion  
    }
}
