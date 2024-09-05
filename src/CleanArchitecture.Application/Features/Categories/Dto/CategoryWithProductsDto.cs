using CleanArchitecture.Application.Features.Products.Dto;

namespace CleanArchitecture.Application.Features.Categories.Dto
{
    public record CategoryWithProductsDto(int Id, string Name, List<ProductDto> Products);
}
