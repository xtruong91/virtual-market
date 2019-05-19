using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using VirtualMarket.Common.Messages;

namespace VirtualMarket.Discounts.Messages.Events
{
    [MessageNamespace("orders")]
    public class OrderCompleted : IEvent
    {
        public Guid Id { get; }
        public Guid CustomerId { get; }
        [JsonConstructor]
        public OrderCompleted(Guid id, Guid customerId)
        {
            Id = id;
            CustomerId = customerId;
        }
    }
}
