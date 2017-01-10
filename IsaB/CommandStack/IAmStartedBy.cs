namespace IsaB.CommandStack
{
    public interface IAmStartedBy<T>  where T : Message
    {
        void Handle(T message); 
    }
}
