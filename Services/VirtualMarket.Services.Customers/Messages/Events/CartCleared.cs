using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using VirtualMarket.Common.Messages;

namespace VirtualMarket.Services.Customers.Messages.Events
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
