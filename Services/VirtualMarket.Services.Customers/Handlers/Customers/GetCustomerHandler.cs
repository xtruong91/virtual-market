using System.Threading.Tasks;
using VirtualMarket.Common.Handlers;
using VirtualMarket.Common.Types;
using VirtualMarket.Services.Customers.Dto;
using VirtualMarket.Services.Customers.Queries;
using VirtualMarket.Services.Customers.Repositories;

namespace VirtualMarket.Services.Customers.Handlers.Customers
{
    public class GetCustomerHandler : IQueryHandler<GetCustomer, CustomerDto>
    {
        private readonly ICustomersRepository _customersRepository;

        public GetCustomerHandler(ICustomersRepository customersRepository)
        {
            _customersRepository = customersRepository;
        }

        public async Task<CustomerDto> HandleAsync(IQuery query)
        {
            var customer = await _customersRepository.GetAsync((query as GetCustomer).Id);
            return customer == null ? null : new CustomerDto
            {
                Id = customer.Id,
                Email = customer.Email,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Address = customer.Address,
                Country = customer.Country,
                CreatedAt = customer.CreatedAt
            };
        }
    }
}
