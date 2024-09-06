using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CleanArchitecture.Persistence
{
    public class GenericRepository<T, TId>(CleanArchitectureDbContext context) : IGenericRepository<T, TId> where T : BaseEntity<TId> where TId : struct
    {
        protected CleanArchitectureDbContext Context = context;

        private readonly DbSet<T> _dbSet = context.Set<T>();
        public async ValueTask AddAsync(T entity) => await _dbSet.AddAsync(entity);
        public Task<bool> AnyAsync(TId id) => _dbSet.AnyAsync(x => x.Id.Equals(id));
        public Task<bool> AnyAsync(Expression<Func<T, bool>> predicate) => _dbSet.AnyAsync(predicate);
        public void Delete(T entity) => _dbSet.Remove(entity);
        public Task<List<T>> GetAllAsync() => _dbSet.ToListAsync();
        public Task<List<T>> GetAllPagedAsync(int pageNumber, int pageSize) => _dbSet.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        public ValueTask<T?> GetByIdAsync(TId id) => _dbSet.FindAsync(id);
        public void Update(T entity) => _dbSet.Update(entity);
        public IQueryable<T> Where(Expression<Func<T, bool>> predicate) => _dbSet.Where(predicate).AsNoTracking();
    }
}
