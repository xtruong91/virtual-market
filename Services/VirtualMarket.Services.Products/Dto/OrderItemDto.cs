using System;

namespace VirtualMarket.Services.Products.Dto
{
    public class OrderItemDto
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
    }
}
