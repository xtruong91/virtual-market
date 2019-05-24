using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VirtualMarket.Common.Mongo;
using VirtualMarket.Common.Types;
using VirtualMarket.Services.Orders.Domain;
using VirtualMarket.Services.Orders.Queries;

namespace VirtualMarket.Services.Orders.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly IMongoRepository<Order> _repository;

        public OrdersRepository(IMongoRepository<Order> repository)
            => _repository = repository;

        public async Task AddAsync(Order order)
        => await _repository.AddAsync(order);

        public async Task<PagedResult<Order>> BrowseAsync(BrowseOrders query)
        => await _repository.BrowseAsync(o => o.CustomerId == query.CustomerId, query);

        public async Task DeleteAsync(Guid id)
        => await _repository.DeleteAsync(id);

        public async Task<Order> GetAsync(Guid id)
        => await _repository.GetAsync(id);

        public async Task<bool> HasPendingOrder(Guid customerId)
            => await _repository.ExistsAsync(o => o.CustomerId == customerId &&
            (o.Status == Order.OrderStatus.Canceled || o.Status == Order.OrderStatus.Approved));
        public async Task UpdateAsync(Order order)
        => await _repository.UpdateAsync(order);
    }
}
