using Newtonsoft.Json;
using System;

namespace VirtualMarket.Services.Messages.Events.Products
{
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
