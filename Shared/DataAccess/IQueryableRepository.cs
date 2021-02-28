using System.Linq;
using Shared.Entities;

namespace Shared.DataAccess
{
    public interface IQueryableRepository<T> where T:class, IEntity,new()
    {
        IQueryable<T> Table { get; }
    }
}
