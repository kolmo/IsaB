using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsaB.Infrastructure
{
    public interface IRepository
    {
        T GetById<T>(int id) where T : IEntity;
        void Save<T>(T item) where T : IEntity;
        void Delete<T>(T item) where T : IEntity;
    }
}
