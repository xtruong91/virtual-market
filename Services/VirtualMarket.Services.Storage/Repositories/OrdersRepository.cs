using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VirtualMarket.Common.Mongo;
using VirtualMarket.Common.Types;
using VirtualMarket.Services.Storage.Models.Orders;
using VirtualMarket.Services.Storage.Models.Queries;

namespace VirtualMarket.Services.Storage.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly IMongoRepository<Order> _repository;

        public OrdersRepository(IMongoRepository<Order> repository)
        {
            _repository = repository;
        }

        public async Task<Order> GetAsync(Guid id)
            => await _repository.GetAsync(id);

        public async Task<PagedResult<Order>> BrowseAsync(BrowseOrders query)
            => await _repository.BrowseAsync(o => o.CustomerId == query.CustomerId, query);

        public async Task CreateAsync(Order order)
            => await _repository.CreateAsync(order);

        public async Task UpdateAsync(Order order)
            => await _repository.UpdateAsync(order);
    }
}
