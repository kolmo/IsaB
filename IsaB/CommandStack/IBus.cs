﻿namespace IsaB.CommandStack
{
    public interface IBus
    {
        void Send<T>(T command) where T : Message;
        void RegisterSaga<T, S>();
    }
}
