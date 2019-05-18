using Newtonsoft.Json;
using System;
using VirtualMarket.Common.Messages;

namespace VirtualMarket.Services.Customers.Messages.Events
{
    [MessageNamespace("products")]
    public class ProductDeleted : IEvent
    {
        public Guid Id { get; }
        
        [JsonConstructor]
        public ProductDeleted(Guid id)
        {
            Id = id;
        }
    }
}
