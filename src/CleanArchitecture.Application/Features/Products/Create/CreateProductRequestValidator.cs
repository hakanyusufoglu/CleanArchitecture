using CleanArchitecture.Application.Contracts.Persistence;
using FluentValidation;

namespace CleanArchitecture.Application.Features.Products.Create
{
    public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
    {
        private readonly IProductRepository _productRepository;

        public CreateProductRequestValidator(IProductRepository productRepository)
        {
            _productRepository = productRepository;

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("ürün ismi gereklidir.")
                .Length(3,10).WithMessage("ürün ismi 3 ile 10 karakter arasında olmalıdır.");

            //price validation
            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("ürün fiyatı 0'dan büyük olmalıdır.");

            //category validation
            RuleFor(x => x.CategoryId)
                .GreaterThan(0).WithMessage("ürün kategori değeri 0'dan büyük olmalıdır.");

            //stock inclusivebetween validation
            RuleFor(x => x.Stock)
                .InclusiveBetween(1, 100).WithMessage("ürün stok değeri 1 ile 100 arasında olmalıdır.");
        }
    }
}
