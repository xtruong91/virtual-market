using System;
using System.Threading.Tasks;
using VirtualMarket.Common.Mongo;
using VirtualMarket.Common.Types;
using VirtualMarket.Services.Products.Domain;
using VirtualMarket.Services.Products.Queries;

namespace VirtualMarket.Services.Products.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly IMongoRepository<Product> _repository;
        public ProductsRepository(IMongoRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(Product product)
        => await _repository.AddAsync(product);

        public async Task<PagedResult<Product>> BrowseAsync(BrowseProducts query)
        => await _repository.BrowseAsync(p =>
                        p.Price >= query.PriceFrom && p.Price <= query.PriceTo, query);

        public async Task DeleteAsync(Guid id)
        => await _repository.DeleteAsync(id);

        public async Task<bool> ExistsAsync(Guid id)
        => await _repository.ExistsAsync(p => p.Id == id);

        public async Task<bool> ExistsAsync(string name)
        => await _repository.ExistsAsync(p => p.Name == name.ToLowerInvariant());

        public async Task<Product> GetAsync(Guid id)
        => await _repository.GetAsync(id);

        public async Task UpdateAsync(Product product)
        => await _repository.UpdateAsync(product);
    }
}
