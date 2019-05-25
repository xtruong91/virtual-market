using Newtonsoft.Json;
using System;

namespace VirtualMarket.Services.Messages.Events.Products
{
    public class ProductCreated : IEvent
    {
        public Guid Id { get; }

        [JsonConstructor]
        public ProductCreated(Guid id)
        {
            Id = id;
        }
    }
}
