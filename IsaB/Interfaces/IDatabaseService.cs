using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsaB.Interfaces.Services
{
    public interface IDatabaseService
    {
        string DatabasePath { get; }
        void InitializeDataSource();
    }
}
