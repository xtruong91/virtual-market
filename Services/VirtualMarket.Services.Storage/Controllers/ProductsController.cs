using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using VirtualMarket.Services.Storage.Models.Queries;
using VirtualMarket.Services.Storage.Repositories;

namespace VirtualMarket.Services.Storage.Controllers
{
    public class ProductsController : BaseController
    {
        private readonly IProductsRepository _productsRepository;

        public ProductsController(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get(BrowseProducts query)
            => Collection(await _productsRepository.BrowseAsync(query));

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
            => Single(await _productsRepository.GetAsync(id));
    }
}
