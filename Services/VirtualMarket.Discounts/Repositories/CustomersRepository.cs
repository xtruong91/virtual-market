using System;
using System.Threading.Tasks;
using VirtualMarket.Common.Mongo;
using VirtualMarket.Discounts.Domain;

namespace VirtualMarket.Discounts.Repositories
{
    public class CustomersRepository : ICustomersRepository
    {
        public readonly IMongoRepository<Customer> _repository;

        public CustomersRepository(IMongoRepository<Customer> repository)
        {
            _repository = repository;
        }
        public async Task AddAsync(Customer customer)
            => await _repository.AddAsync(customer);

        public async Task<Customer> GetAsync(Guid id)
            => await _repository.GetAsync(id);
    }
}
