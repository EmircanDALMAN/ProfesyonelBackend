using System;
using System.Collections.Generic;
using System.Transactions;
using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using DataAccess.Abstract;
using Entities.Concrete;
using Shared.Utilities.Results;
using Shared.Aspects.Postsharp;
using Shared.Aspects.Postsharp.AuthorizationAspects;
using Shared.Aspects.Postsharp.CacheAspects;
using Shared.Aspects.Postsharp.LogAspects;
using Shared.Aspects.Postsharp.PerformanceAspects;
using Shared.Aspects.Postsharp.TransactionAspects;
using Shared.Aspects.Postsharp.ValidationAspects;
using Shared.CrossCuttingConcerns.Caching.Microsoft;
using Shared.CrossCuttingConcerns.Logging.Log4Net.Loggers;

namespace Business.Concrete.Managers
{
    [PerformanceCounterAspect]
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }


        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        //[LogAspect(typeof(DatabaseLogger))]
        //[LogAspect(typeof(FileLogger))]
        [SecuredOperation(Roles="admin,student")]
        public IDataResult<List<Product>> GetList()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetList());
        }

        public IDataResult<List<Product>> GetListByCategory(int categoryId)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetList(c => c.CategoryId == categoryId));
        }

        [FluentValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        //[LogAspect(typeof(FileLogger))]
        public IDataResult<Product> Add(Product product)
        {

            return new SuccessDataResult<Product>(_productDal.Add(product));
        }

        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new SuccessResult();
        }

        [FluentValidationAspect(typeof(ProductValidator))]
        public IDataResult<Product> Update(Product product)
        {

            return new SuccessDataResult<Product>(_productDal.Update(product));
        }

        [TransactionScopeAspect]
        [FluentValidationAspect(typeof(ProductValidator))]
        public IResult TransactionalOperation(Product product1, Product product2)
        {
            _productDal.Add(product1);
            _productDal.Update(product2);
            return new SuccessResult();
        }
    }
}
