using System.Collections.Generic;
using Entities.ComplexTypes;
using Entities.Concrete;
using Shared.DataAccess;

namespace DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {
        List<ProductDetail> GetProductDetails();
    }
}
