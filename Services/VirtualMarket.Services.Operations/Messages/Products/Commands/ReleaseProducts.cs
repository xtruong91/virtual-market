using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using VirtualMarket.Common.Messages;

namespace VirtualMarket.Services.Operations.Messages.Products.Commands
{
    [MessageNamespace("products")]
    public class ReleaseProducts : ICommand
    {
        public Guid OrderId { get; }
        public IDictionary<Guid, int> Products { get; }

        [JsonConstructor]
        public ReleaseProducts(Guid orderId, IDictionary<Guid, int> products)
        {
            OrderId = orderId;
            Products = products;
        }
    }
}
