using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.CategoryId).NotEmpty().WithMessage("Kategori Seçilmelidir");
            RuleFor(p => p.ProductName).NotEmpty().WithMessage("Ürün Adı Boş Bırakılamaz");
            RuleFor(p => p.UnitPrice).NotEmpty().WithMessage("Ürün Fiyatı Boş Bırakılamaz ");
            RuleFor(p => p.UnitPrice).GreaterThan(0).WithMessage("Ürün Fiyatı 0'dan Küçük Olamaz");
            RuleFor(p => p.QuantityPerUnit).NotEmpty().WithMessage("Ürün İçeriği Boş Bırakılamaz");
        }
    }
}
