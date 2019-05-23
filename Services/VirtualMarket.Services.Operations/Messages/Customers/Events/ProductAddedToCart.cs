using Newtonsoft.Json;
using System;
using VirtualMarket.Common.Messages;

namespace VirtualMarket.Services.Operations.Messages.Customers.Events
{
    [MessageNamespace("customers")]
    public class ProductAddedToCart : IEvent
    {
        public Guid CustomerId { get; }
        public Guid ProductId { get; }
        public int Quantity { get; }
        [JsonConstructor]
        public ProductAddedToCart(Guid customerId, Guid productId,
            int quantity)
        {
            CustomerId = customerId;
            ProductId = productId;
            Quantity = quantity;
        }
    }
}
