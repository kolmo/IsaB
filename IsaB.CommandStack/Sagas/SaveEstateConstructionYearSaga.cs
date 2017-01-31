using System;
using IsaB.CommandStack.Commands;
using IsaB.Infrastructure;

namespace IsaB.CommandStack.Sagas
{
    public class SaveEstateConstructionYearSaga : Infrastructure.Saga, IAmStartedBy<SaveEstateConstructionYearCommand>
    {
        public SaveEstateConstructionYearSaga(IBus bus, IRepository repository) : base(bus, repository)
        {
        }

        public void Handle(SaveEstateConstructionYearCommand message)
        {
            if (message!= null)
            {
                var estate = Repository.GetById<Entities.ImmobilieEntity>(message.EstateId);
                if (estate.Baujahr != message.ConstructionYear)
                {
                    estate.Baujahr = message.ConstructionYear;
                    Repository.Save(estate);
                }
            }
        }
    }
}
