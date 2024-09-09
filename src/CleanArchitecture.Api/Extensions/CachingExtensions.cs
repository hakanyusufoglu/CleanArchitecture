using CleanArchitecture.Application.Contracts.Caching;
using CleanArchitecture.Caching;

namespace CleanArchitecture.Api.Extensions
{
    public static class CachingExtensions
    {
        public static IServiceCollection AddCachingExt(this IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddSingleton<ICacheService, CacheService>();

            return services;
        }
    }
}
