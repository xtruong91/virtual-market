using System;
using System.Threading.Tasks;
using VirtualMarket.Common.Mongo;
using VirtualMarket.Services.Orders.Domain;

namespace VirtualMarket.Services.Orders.Repositories
{
    public class CustomersRepository : ICustomersRepository
    {
        private readonly IMongoRepository<Customer> _customersRepository;

        public CustomersRepository(IMongoRepository<Customer> customersRepository)
            => _customersRepository = customersRepository;

        public async Task AddAsync(Customer customer)
         => await _customersRepository.AddAsync(customer);

        public async Task<Customer> GetAsync(Guid id)
        => await _customersRepository.GetAsync(id);
    }
}
