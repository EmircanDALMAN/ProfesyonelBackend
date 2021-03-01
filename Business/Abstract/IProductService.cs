using System.Collections.Generic;
using System.ServiceModel;
using Entities.Concrete;
using Shared.Utilities.Results;

namespace Business.Abstract
{
    [ServiceContract]
    public interface IProductService
    {
        [OperationContract]
        IDataResult<Product> GetById(int productId);
        [OperationContract]
        IDataResult<List<Product>> GetList();
        [OperationContract]
        IDataResult<List<Product>> GetListByCategory(int categoryId);
        [OperationContract]
        IDataResult<Product> Add(Product product);
        [OperationContract]
        IResult Delete(Product product);
        [OperationContract]
        IDataResult<Product> Update(Product product);
        [OperationContract]
        IResult TransactionalOperation(Product product1, Product product2);
    }
}
