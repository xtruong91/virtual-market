using Newtonsoft.Json;
using System;

namespace VirtualMarket.Services.Messages.Commands.Products
{
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
