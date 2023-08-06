using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.eShopWeb.Web.Extensions;
using Microsoft.eShopWeb.Web.ViewModels;
using Microsoft.Extensions.Caching.Distributed;

namespace Microsoft.eShopWeb.Web.Services;

public class CachedCatalogViewModelService : ICatalogViewModelService
{
    private readonly IDistributedCache _cache;
    private readonly CatalogViewModelService _catalogViewModelService;

    public CachedCatalogViewModelService(IDistributedCache cache,
        CatalogViewModelService catalogViewModelService)
    {
        _cache = cache;
        _catalogViewModelService = catalogViewModelService;
    }

    public async Task<IEnumerable<SelectListItem>> GetBrands()
    {
        return (await _cache.GetOrCreateAsync<IEnumerable<SelectListItem>>(CacheHelpers.GenerateBrandsCacheKey(), async () =>
                {
                    return await _catalogViewModelService.GetBrands();
                })) ?? new List<SelectListItem>();
    }

    public async Task<CatalogIndexViewModel> GetCatalogItems(int pageIndex, int itemsPage, int? brandId, int? typeId)
    {
        var cacheKey = CacheHelpers.GenerateCatalogItemCacheKey(pageIndex, Constants.ITEMS_PER_PAGE, brandId, typeId);
        return (await _cache.GetOrCreateAsync<CatalogIndexViewModel>(cacheKey, async () =>
        {
            return await _catalogViewModelService.GetCatalogItems(pageIndex, itemsPage, brandId, typeId);
        })) ?? new CatalogIndexViewModel();
    }

    public async Task<IEnumerable<SelectListItem>> GetTypes()
    {
        return (await _cache.GetOrCreateAsync<IEnumerable<SelectListItem>>(CacheHelpers.GenerateTypesCacheKey(), async () =>
        {
            return await _catalogViewModelService.GetTypes();
        })) ?? new List<SelectListItem>();
    }
}
