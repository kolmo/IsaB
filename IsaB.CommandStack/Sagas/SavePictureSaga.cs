using IsaB.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IsaB.CommandStack.Commands;

namespace IsaB.CommandStack.Sagas
{
    public class SavePictureSaga : Saga, IAmStartedBy<SavePictureCommand>
    {
        public SavePictureSaga(IBus bus, IRepository repository) : base(bus, repository)
        {
        }

        public void Handle(SavePictureCommand message)
        {
            if (message!= null)
            {
                var estatePicture = Entities.ImmobilieBildEntity.Factory.CreateNewInstance(message.EstateId, message.PictureData);
                Repository.Save(estatePicture);
            }
        }
    }
}
