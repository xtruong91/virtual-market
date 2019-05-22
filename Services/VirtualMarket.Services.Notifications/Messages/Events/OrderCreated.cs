using Newtonsoft.Json;
using System;
using VirtualMarket.Common.Messages;

namespace VirtualMarket.Services.Notifications.Messages.Events
{
    [MessageNamespace("orders")]
    public class OrderCreated : IEvent
    {
        public Guid Id { get; }
        public Guid CustomerId { get; }
        [JsonConstructor]
        public OrderCreated(Guid id, Guid customerId)
        {
            Id = id;
            CustomerId = customerId;
        }
    }
}
