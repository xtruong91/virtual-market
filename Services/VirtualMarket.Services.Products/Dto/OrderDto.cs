using System;
using System.Collections.Generic;

namespace VirtualMarket.Services.Products.Dto
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public IEnumerable<OrderItemDto> Items { get; set; }
    }
}
