using IsaB.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IsaB.CommandStack.Commands;
using IsaB.Entities;

namespace IsaB.CommandStack.Sagas
{
    public class CreateNewEstateSaga : Saga, IAmStartedBy<CreateNewEstateCommand>
    {
        public CreateNewEstateSaga(IBus bus, IRepository repository)
            :base(bus, repository)
        {

        }
        public void Handle(CreateNewEstateCommand message)
        {
            if (message!= null)
            {
                Entities.ImmobilieEntity estate = Entities.ImmobilieEntity.Factory.CreateNewInstance(message.NewStreet, message.NewCity, message.BuildingKind);
                Repository.Save(estate);
            }
        }
    }
}
