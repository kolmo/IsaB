using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IsaB.Infrastructure
{
    public abstract class Saga
    {
        public IBus Bus { get; private set; }
        public IRepository Repository { get;}
        public Saga(IBus bus, IRepository repository)
        {
            if (bus == null)
            {
                throw new ArgumentNullException(nameof(bus));
            }
            if (repository == null)
            {
                throw new ArgumentNullException(nameof(repository));
            }
            Bus = bus;
            Repository = repository;
        }
    }
}
