using IsaB.CommandStack.Commands;
using IsaB.Entities;
using IsaB.Infrastructure;

namespace IsaB.CommandStack.Sagas
{
    public class DeleteEstateSaga : Saga, IAmStartedBy<DeleteEstateCommand>
    {
        public DeleteEstateSaga(IBus bus, IRepository repository) : base(bus, repository)
        {
        }

        public void Handle(DeleteEstateCommand message)
        {
            if (message!= null)
            {
                var estate = Repository.GetById<ImmobilieEntity>(message.EstateId);
                if (estate!= null)
                {
                    Repository.Delete(estate);
                }
            }
        }
    }
}
