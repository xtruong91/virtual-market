using System;
using System.Threading.Tasks;
using VirtualMarket.Common.Types;
using VirtualMarket.Services.Storage.Models.Customers;
using VirtualMarket.Services.Storage.Models.Queries;

namespace VirtualMarket.Services.Storage.Repositories
{
    public interface ICustomersRepository
    {
        Task<Customer> GetAsync(Guid id);
        Task<PagedResult<Customer>> BrowseAsync(BrowseCustomers query);
        Task CreateAsync(Customer customer);
    }
}
