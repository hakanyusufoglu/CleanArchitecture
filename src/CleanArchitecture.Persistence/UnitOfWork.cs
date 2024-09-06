using CleanArchitecture.Application.Contracts.Persistence;

namespace CleanArchitecture.Persistence
{
    public class UnitOfWork(CleanArchitectureDbContext context) : IUnitOfWork
    {
        public Task<int> SaveChangesAsync() => context.SaveChangesAsync();
    }
}
