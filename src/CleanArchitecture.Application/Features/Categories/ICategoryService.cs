using CleanArchitecture.Application.Features.Categories.Create;
using CleanArchitecture.Application.Features.Categories.Dto;
using CleanArchitecture.Application.Features.Categories.Update;

namespace CleanArchitecture.Application.Features.Categories
{
    public interface ICategoryService
    {
        Task<ServiceResult<CategoryWithProductsDto>> GetCategoryWithProductsAsync(int categoryId);
        Task<ServiceResult<List<CategoryWithProductsDto>>> GetCategoryWithProductsAsync();
        Task<ServiceResult<List<CategoryDto>>> GetAllListAsync();
        Task<ServiceResult<CategoryDto>> GetByIdAsync(int id);
        Task<ServiceResult<int>> CreateAsync(CreateCategoryRequest request);
        Task<ServiceResult> UpdateAsync(int id, UpdateCategoryRequest request);
        Task<ServiceResult> DeleteAsync(int id);
    }
}
