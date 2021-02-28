using Entities.Concrete;
using FluentNHibernate.Mapping;

namespace DataAccess.Concrete.NHibernate.Mappings
{
    public class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {
            Table(@"Products");
            LazyLoad();
            Id(x => x.ProductId).Column("ProductId");
            Map(x => x.CategoryId).Column("CategoryId");
            Map(x => x.UnitPrice).Column("UnitPrice");
            Map(x => x.QuantityPerUnit).Column("QuantityPerUnit");
            Map(x => x.ProductName).Column("ProductName");
        }
    }
}
