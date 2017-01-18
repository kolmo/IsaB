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
    public class DeletePictureSaga : Saga, IAmStartedBy<Commands.DeletePictureCommand>
    {
        public DeletePictureSaga(IBus bus, IRepository repository) : base(bus, repository)
        {
        }

        public void Handle(DeletePictureCommand message)
        {
            if (message!= null)
            {
               var picture = Repository.GetById<ImmobilieBildEntity>(message.PictureID);
                if (picture!= null)
                {
                    Repository.Delete(picture);
                }
            }
        }
    }
}
