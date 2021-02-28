using Entities.Concrete;
using Shared.DataAccess;

namespace DataAccess.Abstract
{
    public interface ICategoryDal : IEntityRepository<Category>
    {
    }
}
