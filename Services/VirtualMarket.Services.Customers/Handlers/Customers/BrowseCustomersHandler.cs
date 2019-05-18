using System.Linq;
using System.Threading.Tasks;
using VirtualMarket.Common.Handlers;
using VirtualMarket.Common.Types;
using VirtualMarket.Services.Customers.Dto;
using VirtualMarket.Services.Customers.Queries;
using VirtualMarket.Services.Customers.Repositories;

namespace VirtualMarket.Services.Customers.Handlers.Customers
{
    public class BrowseCustomersHandler : IQueryHandler<BrowseCustomers, PagedResult<CustomerDto>>
    {
        private readonly ICustomersRepository _customersRepository;

        public BrowseCustomersHandler(ICustomersRepository customersRepository)
        {
            _customersRepository = customersRepository;
        }
        public async Task<PagedResult<CustomerDto>> HandleAsync(IQuery query)
        {
            var pagedResult = await _customersRepository.BrowseAsync(query as BrowseCustomers);
            var customers = pagedResult.Items.Select(c => new CustomerDto
            {
                Id = c.Id,
                Email = c.Email,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Address = c.Address,
                Country = c.Country,
                CreatedAt = c.CreatedAt,
                Completed = c.Completed
            });
            return PagedResult<CustomerDto>.From(pagedResult, customers);
        }
    }
}
