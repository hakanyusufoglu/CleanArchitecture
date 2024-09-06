using System.Linq.Expressions;

namespace CleanArchitecture.Application.Contracts.Persistence
{
    public interface IGenericRepository<T, TId> where T : class where TId : struct
    {
        public Task<bool> AnyAsync(TId id);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllPagedAsync(int pageNumber, int pageSize);
        IQueryable<T> Where(Expression<Func<T, bool>> predicate);
        ValueTask<T?> GetByIdAsync(TId id);
        Task<T> AddAsync(T entity);
        void Update(T entity);
        void Delete (T entity);
    }
}
