using System.Collections.Generic;
using System.Threading.Tasks;

namespace IsaB.Interfaces.Services
{
    public interface ISeedLoaderService
    {
        string DatabasePath { get; }
        List<string> GetSeedStringFromList();
    }
}
