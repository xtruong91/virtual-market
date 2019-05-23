using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using VirtualMarket.Common.Messages;

namespace VirtualMarket.Services.Operations.Messages.Orders.Events
{
    [MessageNamespace("orders")]
    public class OrderCreated : IEvent
    {
        public Guid Id { get; }
        public Guid CustomerId { get; }
        public IDictionary<Guid, int> Products { get; }
        [JsonConstructor]
        public OrderCreated(Guid id, Guid customerId, IDictionary<Guid, int> products)
        {
            Id = id;
            CustomerId = customerId;
            Products = products;
        }
    }
}
