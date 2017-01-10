using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsaB.Infrastructure
{ 
    public interface IAggregate
    {
        Guid Id { get; }

        bool HasPendingChanges { get; }

        IEnumerable<DomainEvent> GetUncommittedEvents();

        void ClearUncommittedEvents();
    }
}
