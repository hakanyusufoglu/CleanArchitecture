using CleanArchitecture.Application.Features.Products.Create;
using CleanArchitecture.Application.Features.Products.Dto;
using CleanArchitecture.Application.Features.Products.Update;
using CleanArchitecture.Application.Features.Products.UpdateStock;

namespace CleanArchitecture.Application.Features.Products
{
    public interface IProductService
    {
        Task<ServiceResult<List<ProductDto>>> GetTopPriceProductsAsync(int count);
        Task<ServiceResult<ProductDto>> GetByIdAsync(int id);
        Task<ServiceResult<List<ProductDto>>> GetAllListAsync();
        Task<ServiceResult<List<ProductDto>>> GetPagedAllListAsync(int pageNumber, int pageSize);
        Task<ServiceResult<CreateProductResponse>> CreateAsync(CreateProductRequest request);
        Task<ServiceResult> UpdateAsync(int id, UpdateProductRequest request);
        Task<ServiceResult> UpdateStockAsync(UpdateProductsStockRequest request);
        Task<ServiceResult> DeleteAsync(int id);
    }
}
