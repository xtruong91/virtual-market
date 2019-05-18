using System;
using VirtualMarket.Common.Messages;

namespace VirtualMarket.Services.Customers.Messages.Events
{
    public class ProductAddedToCart : IEvent
    {
        public Guid CustomerId { get; }
        public Guid ProductId { get; }
        public int Quantity { get; }

        public ProductAddedToCart(Guid customerId, Guid productId, int quantity)
        {
            CustomerId = customerId;
            ProductId = productId;
            Quantity = quantity;
        }
    }
}
