using System;
using System.Threading.Tasks;
using VirtualMarket.Common.Types;
using VirtualMarket.Services.Storage.Models.Orders;
using VirtualMarket.Services.Storage.Models.Queries;

namespace VirtualMarket.Services.Storage.Repositories
{
    public interface IOrdersRepository
    {
        Task<Order> GetAsync(Guid id);
        Task<PagedResult<Order>> BrowseAsync(BrowseOrders query);
        Task CreateAsync(Order product);
        Task UpdateAsync(Order product);
    }
}
