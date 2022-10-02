using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Prj.Net6.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CacheController : ControllerBase
    {
        private readonly IMemoryCache _memoryCache;

        public CacheController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        [HttpGet("{cacheKey}")]
        public async Task<IActionResult> Get(string cacheKey)
        {
            if (_memoryCache.TryGetValue(cacheKey, out var item))
            {
                return Ok(new { item = item });
            }

            item = await LongRunningProcess();

            var options = new MemoryCacheEntryOptions()
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(3600),
                SlidingExpiration = TimeSpan.FromSeconds(1200)
            };

            _memoryCache.Set(cacheKey, item, options);
            return Ok(new { item = item });
        }

        private static async Task<int> LongRunningProcess()
        {
            await Task.Delay(1000);

            var random = new Random();
            return random.Next(1000, 2000);
        }
    }

    //
    // https://medium.com/@luisalexandre.rodrigues/creating-an-in-memory-cache-for-net-6-web-api-3d52d8368081
    //
}
