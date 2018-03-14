using System;
using GateKeeper.Core.Entities;

namespace GateKeeper.Core.Contracts.System
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        T Add(T entity);
        T Delete(T entity);
        void Edit(T entity);
        T GetByID(Guid ID);
    }
}
