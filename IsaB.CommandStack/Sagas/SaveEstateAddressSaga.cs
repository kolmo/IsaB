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
    public class SaveEstateAddressSaga : Saga, IAmStartedBy<SaveEstateAddressCommand>
    {
        public SaveEstateAddressSaga(IBus bus, IRepository repository)
            :base(bus, repository)
        {

        }
        public void Handle(SaveEstateAddressCommand message)
        {
            if (message!= null)
            {
                ImmobilieEntity estate = Repository.GetById<ImmobilieEntity>(message.EstateID);
                if (estate!= null)
                {
                    estate.Strasse = message.Street;
                    estate.Ort = message.City;
                    estate.PLZ = message.Postcode;
                    Repository.Save(estate);
                }
            }
        }
    }
}
