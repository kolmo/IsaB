using IsaB.CommandStack.Commands;
using IsaB.Entities;
using IsaB.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsaB.CommandStack.Sagas
{
    public class SaveEstateLandsizeSaga : Saga, IAmStartedBy<SaveEstateLandsizeCommand>
    {
        public SaveEstateLandsizeSaga(IBus bus, IRepository repository) : base(bus, repository)
        {
        }

        public void Handle(SaveEstateLandsizeCommand message)
        {
            if (message != null)
            {
                ImmobilieEntity estate = Repository.GetById<ImmobilieEntity>(message.EstateID);
                if (estate != null)
                {
                    estate.Grundstuecksflaeche = message.Landsize;
                    estate.Bodenrichtwert = message.StandardGroundValue;
                    estate.Bruttogrundflaeche = message.LivingSpace;
                    Repository.Save(estate);
                }
            }
        }
    }
}
