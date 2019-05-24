using System;
using VirtualMarket.Common.Types;
using VirtualMarket.Services.Orders.Dto;

namespace VirtualMarket.Services.Orders.Queries
{
    public class BrowseOrders : PagedQueryBase, IQuery<PagedResult<OrderDto>>
    {
        public Guid CustomerId { get; set; }
    }
}
