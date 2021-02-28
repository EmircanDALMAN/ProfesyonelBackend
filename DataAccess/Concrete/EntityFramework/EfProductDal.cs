using System.Collections.Generic;
using System.Linq;
using DataAccess.Abstract;
using Entities.ComplexTypes;
using Entities.Concrete;
using Shared.DataAccess.EntityFramework;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    {
        public List<ProductDetail> GetProductDetails()
        {
            using var context = new NorthwindContext();
            var result = from p in context.Products
                join c in context.Categories on p.CategoryId equals c.CategoryId
                select new ProductDetail
                {
                    CategoryName = c.CategoryName,
                    ProductId = p.ProductId,
                    ProductName = p.ProductName
                };
            return result.ToList();
        }
    }
}
