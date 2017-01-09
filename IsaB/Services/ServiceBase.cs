using IsaB.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsaB.Services
{
    public class ServiceBase 
    {
        #region Props
        protected string DbPath { get; private set; }
        #endregion
        public ServiceBase(string dbPath)
        {
            DbPath = dbPath; 
        }
    }
}
