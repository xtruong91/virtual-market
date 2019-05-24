using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualMarket.Services.Orders.Dto
{
  public class OrderDetailsDto : OrderDto
  {
        public CustomerDto Customer { get; set; }
        public IEnumerable<OrderItemDto> Items { get; set; }
  }
}
