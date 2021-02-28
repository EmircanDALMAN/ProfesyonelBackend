using DataAccess.Abstract;
using Entities.Concrete;
using Shared.DataAccess.EntityFramework;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal :EfEntityRepositoryBase<Category,NorthwindContext>,ICategoryDal
    {
    }
}
