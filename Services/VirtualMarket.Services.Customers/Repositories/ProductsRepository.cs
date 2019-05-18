using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VirtualMarket.Common.Mongo;
using VirtualMarket.Services.Customers.Domain;

namespace VirtualMarket.Services.Customers.Repositories
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

        public async Task DeleteAsync(Guid id)
            => await _repository.DeleteAsync(id);

        public async Task<Product> GetAsync(Guid id)
            => await _repository.GetAsync(id);

        public async Task UpdateAsync(Product product)
            => await _repository.UpdateAsync(product);
    }
}
