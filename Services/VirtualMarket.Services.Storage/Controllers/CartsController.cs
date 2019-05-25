using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using VirtualMarket.Services.Storage.Services;

namespace VirtualMarket.Services.Storage.Controllers
{
    public class CartsController : BaseController
    {
        private readonly ICache _cache;

        public CartsController(ICache cache)
        {
            _cache = cache;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
            => Single(await _cache.GetCartAsync(id));
    }
}
