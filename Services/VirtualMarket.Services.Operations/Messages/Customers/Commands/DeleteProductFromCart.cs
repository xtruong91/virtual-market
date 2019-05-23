using Newtonsoft.Json;
using System;
using VirtualMarket.Common.Messages;

namespace VirtualMarket.Services.Operations.Messages.Customers.Commands
{
    [MessageNamespace("customers")]
  public class DeleteProductFromCart : ICommand
  {
        public Guid CustomerId { get; }
        public Guid ProductId { get; }
        [JsonConstructor]
        public DeleteProductFromCart(Guid customerId, Guid productId)
        {
            CustomerId = customerId;
            ProductId = productId;
        }
  }
}
