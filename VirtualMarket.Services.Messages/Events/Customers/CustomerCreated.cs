using Newtonsoft.Json;
using System;

namespace VirtualMarket.Services.Messages.Events.Customers
{
    public class CustomerCreated : IEvent
    {
        public Guid Id { get; }

        [JsonConstructor]
        public CustomerCreated(Guid id)
        {
            Id = id;
        }
    }
}
