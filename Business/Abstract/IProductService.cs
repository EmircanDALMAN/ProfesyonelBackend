using System.Collections.Generic;
using Entities.Concrete;
using Shared.Utilities.Results;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<Product> GetById(int productId);
        IDataResult<List<Product>> GetList();
        IDataResult<List<Product>> GetListByCategory(int categoryId);
        IDataResult<Product> Add(Product product);
        IResult Delete(Product product);
        IDataResult<Product> Update(Product product);
        IResult TransactionalOperation(Product product1, Product product2);
    }
}
