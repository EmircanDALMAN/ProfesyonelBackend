using System.Data.Entity;
using System.Linq;
using Shared.Entities;

namespace Shared.DataAccess.EntityFramework
{
    public class EfQueryableRepository<T> : IQueryableRepository<T> where T:class,IEntity,new()
    {
        private DbContext _dbContext;
        private DbSet<T> _entities;

        public EfQueryableRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<T> Table => Entities;

        protected virtual DbSet<T> Entities
        {
            get { return _entities ??= _dbContext.Set<T>(); }
        }
    }
}
