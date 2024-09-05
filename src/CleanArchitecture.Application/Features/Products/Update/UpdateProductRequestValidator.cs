using FluentValidation;

namespace CleanArchitecture.Application.Features.Products.Update
{
    public class UpdateProductRequestValidator : AbstractValidator<UpdateProductRequest>
    {
        public UpdateProductRequestValidator()
        {
            RuleFor(x=>x.Name)
                .NotEmpty().WithMessage("ürün ismi gereklidir.")
                .Length(3, 10).WithMessage("ürün ismi 3 ile 10 karakter arasında olmalıdır.");

            RuleFor(x=>x.CategoryId)
                .GreaterThan(0).WithMessage("ürün kategori değeri 0'dan büyük olmalıdır.");

            //price validation
            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("ürün fiyatı 0'dan büyük olmalıdır.");

            //stock inclusivebetween validation
            RuleFor(x => x.Stock)
                .InclusiveBetween(1, 100).WithMessage("ürün stok değeri 1 ile 100 arasında olmalıdır.");
        }
    }
}
