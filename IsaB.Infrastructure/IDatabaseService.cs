namespace IsaB.Infrastructure
{
    public interface IDatabaseService
    {
        string ConnectionString { get; }
        void InitializeDataSource();
    }
}
