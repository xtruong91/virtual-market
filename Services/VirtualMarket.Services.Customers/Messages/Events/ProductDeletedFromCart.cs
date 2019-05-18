using System;
using VirtualMarket.Common.Messages;

namespace VirtualMarket.Services.Customers.Messages.Events
{
    public class ProductDeletedFromCart : IEvent
    {
        public Guid CustomerId { get; }
        public Guid ProductId { get; }

        public ProductDeletedFromCart(Guid customerID, Guid productId)
        {
            CustomerId = customerID;
            ProductId = productId;
        }
    }
}
