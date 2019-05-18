using Newtonsoft.Json;
using System;
using VirtualMarket.Common.Messages;

namespace VirtualMarket.Services.Customers.Messages.Commands
{
    public class AddProductToCart : ICommand
    {
        public Guid CustomerId { get; }
        public Guid ProductId { get; }
        public int Quantity { get; }
        [JsonConstructor]
        public AddProductToCart(Guid customerId, Guid productId,
            int quantity)
        {
            CustomerId = customerId;
            ProductId = productId;
            Quantity = quantity;
        }
        
    }
}
