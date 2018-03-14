using GateKeeper.Core.Contracts;
using GateKeeper.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GateKeeper.Core.Contracts.System;

namespace GateKeeper.Gateways
{
    public abstract class BaseRepository<T>: IBaseRepository<T> where T: BaseEntity
    {
        private DbContext context;
        protected readonly DbSet<T> dbset;

        public BaseRepository(DbContext context)
        {
            this.context = context;
            dbset = context.Set<T>();
        }
        public T Add(T entity)
        {
            entity.CreatedDate = DateTimeOffset.Now;
            return dbset.Add(entity).Entity;
        }
        public T Delete(T entity)
        {
            return dbset.Remove(entity).Entity;
        }
        public void Edit(T entity)
        {
            entity.LatestUpdatedDate = DateTimeOffset.Now;
        }
        public T GetByID(Guid ID)
        {
            return dbset.Where(x => x.ID == ID).FirstOrDefault();
        }
    }
}
