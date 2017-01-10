using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsaB.CommandStack
{
    public interface IHandles<T>
    {
        void Handle(T message);
        bool IsComplete();
    }
}
