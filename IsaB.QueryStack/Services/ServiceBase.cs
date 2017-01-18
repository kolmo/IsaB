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
