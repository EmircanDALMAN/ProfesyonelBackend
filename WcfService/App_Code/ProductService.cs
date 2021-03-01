using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Business.Abstract;
using Business.DependencyResolvers.Ninject;
using Entities.Concrete;
using Shared.Utilities.Results;

/// <summary>
/// Summary description for ProductService
/// </summary>
public class ProductService: IProductService
{
    public ProductService()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    private IProductService _productService = InstanceFactory.GetInstance<IProductService>();
    public IDataResult<Product> Add(Product product)
    {
        return new SuccessDataResult<Product>(_productService.Add(product).Data);
    }

    public IResult Delete(Product product)
    {
        _productService.Delete(product);
        return new SuccessResult();
    }

    public IDataResult<Product> GetById(int productId)
    {
        return new SuccessDataResult<Product>(_productService.GetById(productId).Data);
    }

    public IDataResult<List<Product>> GetList()
    {
        return new SuccessDataResult<List<Product>>(_productService.GetList().Data);
    }

    public IDataResult<List<Product>> GetListByCategory(int categoryId)
    {
        return new SuccessDataResult<List<Product>>(_productService.GetListByCategory(categoryId).Data);
    }

    public IResult TransactionalOperation(Product product1, Product product2)
    {
        _productService.TransactionalOperation(product1, product2);
        return new SuccessResult();
    }

    public IDataResult<Product> Update(Product product)
    {
        return new SuccessDataResult<Product>(_productService.Update(product).Data);
    }
}