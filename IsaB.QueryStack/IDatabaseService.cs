﻿namespace IsaB.QueryStack
{
    public interface IDatabaseService
    {
        string ConnectionString { get; }
        void InitializeDataSource();
    }
}
