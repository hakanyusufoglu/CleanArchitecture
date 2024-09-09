﻿using CleanArchitecture.Application.Contracts.Caching;
using Microsoft.Extensions.Caching.Memory;

namespace CleanArchitecture.Caching
{
    public class CacheService(IMemoryCache memoryCache) : ICacheService
    {
        public Task AddAsync<T>(string cacheKey, T value, TimeSpan exTimeSpan)
        {
            var cacheOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = exTimeSpan
            };

            memoryCache.Set(cacheKey, value, cacheOptions);

            return Task.CompletedTask;
        }

        public Task<T?> GetAsync<T>(string cacheKey)
        {
            return Task.FromResult(memoryCache.TryGetValue(cacheKey, out T cacheItem) ? cacheItem : default(T));
        }

        public Task RemoveAsync(string cacheKey)
        {
            memoryCache.Remove(cacheKey);

            return Task.CompletedTask;
        }
    }
}
