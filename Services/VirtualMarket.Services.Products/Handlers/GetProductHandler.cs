using System.Threading.Tasks;
using VirtualMarket.Common.Handlers;
using VirtualMarket.Common.Types;
using VirtualMarket.Services.Products.Dto;
using VirtualMarket.Services.Products.Queries;
using VirtualMarket.Services.Products.Repositories;

namespace VirtualMarket.Services.Products.Handlers
{
    public class GetProductHandler : IQueryHandler<GetProduct, ProductDto>
    {
        private readonly IProductsRepository _productsRepository;

        public GetProductHandler(IProductsRepository productsRepository)
            => _productsRepository = productsRepository;

        public async Task<ProductDto> HandleAsync(IQuery query)
        {
            var product = await _productsRepository.GetAsync((query as GetProduct).Id);

            return product == null ? null : new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Vendor = product.Vendor,
                Price = product.Price
            };
        }
    }
}
