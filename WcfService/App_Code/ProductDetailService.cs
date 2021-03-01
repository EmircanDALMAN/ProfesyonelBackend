using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Business.Abstract;
using Business.DependencyResolvers.Ninject;
using Business.ServiceContracts.Wcf;
using Entities.Concrete;
using Shared.Utilities.Results;

/// <summary>
/// Summary description for ProductDetailService
/// </summary>
public class ProductDetailService:IProductDetailService
{
    private IProductService _productService = InstanceFactory.GetInstance<IProductService>();
    public IDataResult<List<Product>> GetList()
    {
        return new SuccessDataResult<List<Product>>(_productService.GetList().Data);
    }
}