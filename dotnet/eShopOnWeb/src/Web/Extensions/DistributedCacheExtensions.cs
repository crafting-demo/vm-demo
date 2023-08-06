namespace Microsoft.eShopWeb.Web.Extensions;

using System;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;

public static class DistributedCacheExtensions
{
    public static async Task<T> GetOrCreateAsync<T>(this IDistributedCache cache, string key, Func<Task<T>> createItemFunc)
    {
        // Attempt to retrieve the item from the cache
        var cachedData = await cache.GetStringAsync(key);

        if (cachedData != null)
        {
            // If the item exists in the cache, deserialize and return it
            return JsonSerializer.Deserialize<T>(cachedData);
        }

        // If the item doesn't exist in the cache, create it using the provided function
        var newItem = await createItemFunc();
        if (newItem != null)
        {
            // Serialize and store the newly created item in the cache
            await cache.SetStringAsync(key, JsonSerializer.Serialize(newItem), new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = CacheHelpers.DefaultCacheDuration
            });
        }

        return newItem;
    }
}