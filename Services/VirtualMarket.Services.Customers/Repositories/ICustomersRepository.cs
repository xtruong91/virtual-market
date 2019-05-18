using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VirtualMarket.Common.Types;
using VirtualMarket.Services.Customers.Domain;
using VirtualMarket.Services.Customers.Queries;

namespace VirtualMarket.Services.Customers.Repositories
{
    public interface ICustomersRepository
    {
        Task<Customer> GetAsync(Guid id);
        Task<PagedResult<Customer>> BrowseAsync(BrowseCustomers id);
        Task AddAsync(Customer customer);
        Task UpdateAsync(Customer customer);
    }
}
