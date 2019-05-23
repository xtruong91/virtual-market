using Newtonsoft.Json;
using System;
using VirtualMarket.Common.Messages;

namespace VirtualMarket.Services.Operations.Messages.Orders.Events
{
    [MessageNamespace("orders")]
    public class OrderRevoked : IEvent
    {
        public Guid Id { get; }
        public Guid CustomerId { get; }
        [JsonConstructor]
        public OrderRevoked(Guid id, Guid customerId)
        {
            Id = id;
            CustomerId = customerId;
        }
    }
}
