using System.Data.Entity.ModelConfiguration;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework.Mappings
{
    public class CategoryMap : EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            ToTable(@"Categories", @"dbo");
            HasKey(x => x.CategoryId);
            Property(x => x.CategoryName).HasColumnName("CategoryName");
            Property(x => x.CategoryId).HasColumnName("CategoryId");
        }
    }
}
