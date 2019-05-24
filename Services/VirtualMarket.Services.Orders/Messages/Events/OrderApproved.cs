using Newtonsoft.Json;
using System;
using VirtualMarket.Common.Messages;

namespace VirtualMarket.Services.Orders.Messages.Events
{
    public class OrderApproved : IEvent
    {
        public Guid Id { get; }
        public Guid CustomerId { get; }

        [JsonConstructor]
        public OrderApproved(Guid id, Guid customerId)
        {
            Id = id;
            CustomerId = customerId;
        }
    }
}
