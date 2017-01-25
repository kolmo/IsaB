using IsaB.Base;

namespace IsaB.Infrastructure
{
    public interface IRepository
    {
        T GetById<T>(int id) where T : Entity, new();
        void Save<T>(T item) where T : Entity, new();
        void Delete<T>(T item) where T : Entity, new();
    }
}
