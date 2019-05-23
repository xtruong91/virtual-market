using Newtonsoft.Json;
using System;
using VirtualMarket.Common.Messages;

namespace VirtualMarket.Services.Operations.Messages.Customers.Events
{
    [MessageNamespace("customers")]
    public class ProductDeletedFromCart : IEvent
    {
        public Guid CustomerId { get; }
        public Guid ProductId { get; }
        public int Quantity { get; }
        [JsonConstructor]
        public ProductDeletedFromCart(Guid customerId, Guid productId, int quantity)
        {
            CustomerId = customerId;
            ProductId = productId;
            Quantity = quantity;
        }
    }
}
