using Newtonsoft.Json;
using System;
using VirtualMarket.Common.Messages;

namespace VirtualMarket.Services.Operations.Messages.Products.Commands
{
    [MessageNamespace("products")]
    public class DeleteProduct : ICommand
    {
        public Guid Id { get; }
        [JsonConstructor]
        public DeleteProduct(Guid id)
        {
            Id = id;
        }
    }
}
