using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistence.Categories
{
    public class CategoryRepository(CleanArchitectureDbContext context) : GenericRepository<Category, int>(context), ICategoryRepository
    {
        public Task<Category?> GetCategoryWithProductsAsync(int id) => context.Categories.Include(x => x.Products).FirstOrDefaultAsync(x => x.Id == id);

        public Task<List<Category>> GetCategoryWithProductsAsync() => context.Categories.Include(x => x.Products).ToListAsync();
        public IQueryable<Category> GetCategoryWithProducts() => context.Categories.Include(x => x.Products).AsQueryable();
    }
}
