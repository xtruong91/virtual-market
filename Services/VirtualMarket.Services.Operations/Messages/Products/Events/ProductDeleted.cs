using System;
using VirtualMarket.Common.Messages;

namespace VirtualMarket.Services.Operations.Messages.Products.Events
{
    [MessageNamespace("products")]
    public class ProductDeleted : IEvent
    {
        public Guid Id { get; }
        public ProductDeleted(Guid id)
        {
            Id = id;
        }
    }
}
