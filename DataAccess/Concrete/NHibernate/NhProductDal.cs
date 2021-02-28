using System.Collections.Generic;
using System.Linq;
using DataAccess.Abstract;
using Entities.ComplexTypes;
using Entities.Concrete;
using Shared.DataAccess.NHibernate;

namespace DataAccess.Concrete.NHibernate
{
    public class NhProductDal : NhEntityRepositoryBase<Product>, IProductDal
    {
        private readonly NHibernateHelper _nHibernateHelper;
        public NhProductDal(NHibernateHelper nHibernateHelper) : base(nHibernateHelper)
        {
            _nHibernateHelper = nHibernateHelper;
        }

        public List<ProductDetail> GetProductDetails()
        {
            using var session = _nHibernateHelper.OpenSession();
            var result = from p in session.Query<Product>()
                join c in session.Query<Category>() on p.CategoryId equals c.CategoryId
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
