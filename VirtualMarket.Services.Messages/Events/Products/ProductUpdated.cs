using Newtonsoft.Json;
using System;

namespace VirtualMarket.Services.Messages.Events.Products
{
    public class ProductUpdated : IEvent
    {
        public Guid Id { get; }

        [JsonConstructor]
        public ProductUpdated(Guid id)
        {
            Id = id;
        }
    }
}
