using System.Linq;
using System.Threading.Tasks;
using VirtualMarket.Common.Handlers;
using VirtualMarket.Common.Types;
using VirtualMarket.Services.Products.Dto;
using VirtualMarket.Services.Products.Queries;
using VirtualMarket.Services.Products.Repositories;

namespace VirtualMarket.Services.Products.Handlers
{
    public sealed class BrowseProductsHandler : IQueryHandler<BrowseProducts, PagedResult<ProductDto>>
    {
        private readonly IProductsRepository _productsRepository;
        public BrowseProductsHandler(IProductsRepository productsRepository)
            => _productsRepository = productsRepository;

        public async Task<PagedResult<ProductDto>> HandleAsync(IQuery query)
        {
            var pagedResult = await _productsRepository.BrowseAsync(query as BrowseProducts);
            var products = pagedResult.Items.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Vendor = p.Vendor,
                Price = p.Price,
                Quantity = p.Quantity
            }).ToList();
            return PagedResult<ProductDto>.From(pagedResult, products);
        }
    }
}
