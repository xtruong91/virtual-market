using System;
using System.Threading.Tasks;
using VirtualMarket.Common.Mongo;
using VirtualMarket.Common.Types;
using VirtualMarket.Services.Customers.Domain;
using VirtualMarket.Services.Customers.Queries;

namespace VirtualMarket.Services.Customers.Repositories
{
    public class CustomersRepository : ICustomersRepository
    {
        private readonly IMongoRepository<Customer> _repository;

        public CustomersRepository(IMongoRepository<Customer> repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(Customer customer)
            => await _repository.AddAsync(customer);

        public async Task<PagedResult<Customer>> BrowseAsync(BrowseCustomers query)
            => await _repository.BrowseAsync(_ => true, query);

        public async Task<Customer> GetAsync(Guid id)
            => await _repository.GetAsync(id);

        public async Task UpdateAsync(Customer customer)
            => await _repository.UpdateAsync(customer);
    }
}
