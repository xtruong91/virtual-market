using Newtonsoft.Json;
using System;
using VirtualMarket.Common.Messages;

namespace VirtualMarket.Services.Operations.Messages.Customers.Events
{
    public class CartCleared : IEvent
    {
        public Guid CustomerId { get; }
        [JsonConstructor]
        public CartCleared(Guid customerId)
        {
            CustomerId = customerId;
        }
    }
}
