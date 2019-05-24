using System;
using System.Threading.Tasks;
using VirtualMarket.Common.Types;
using VirtualMarket.Services.Orders.Domain;
using VirtualMarket.Services.Orders.Queries;

namespace VirtualMarket.Services.Orders.Repositories
{
    public interface IOrdersRepository
    {
        Task<bool> HasPendingOrder(Guid customerId);
        Task<Order> GetAsync(Guid id);
        Task<PagedResult<Order>> BrowseAsync(BrowseOrders query);
        Task AddAsync(Order order);
        Task UpdateAsync(Order order);
        Task DeleteAsync(Guid id);
    }
}
