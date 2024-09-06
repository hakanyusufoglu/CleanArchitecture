using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistence.Products
{
    internal class ProductRepository(CleanArchitectureDbContext context) : GenericRepository<Product, int>(context), IProductRepository
    {
        public Task<List<Product>> GetTopPriceProductsAsync(int count) => context.Products.OrderByDescending(p => p.Price).Take(count).ToListAsync();
    }
}
