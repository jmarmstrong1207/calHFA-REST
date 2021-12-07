using System;
using Microsoft.Extensions.Caching.Memory;

namespace CalHFA_API
{
    public static class Caching
    {
        private static IMemoryCache _cache = new MemoryCache(new MemoryCacheOptions());

        public static void Add(int count, string date)
        {
            var expiration = new MemoryCacheEntryOptions()
            {
                //expiration set for two hours
                AbsoluteExpiration = DateTime.Now.AddMinutes(120),
                Priority = CacheItemPriority.High,
            };
            _cache.Set(count, date, expiration);
        }
        public static int GetCount(int count)
        {
            _cache.Get(count);
            return count;
        }
        public static string GetDate(string date)
        {
            _cache.Get(date);
            return date;
        }
    }
}
