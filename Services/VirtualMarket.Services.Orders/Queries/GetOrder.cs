using System;
using VirtualMarket.Common.Types;
using VirtualMarket.Services.Orders.Dto;

namespace VirtualMarket.Services.Orders.Queries
{
    public class GetOrder : IQuery<OrderDetailsDto>
    {
        public Guid OrderId { get; set; }
        public Guid? CustomerId { get; set; }
    }
}
