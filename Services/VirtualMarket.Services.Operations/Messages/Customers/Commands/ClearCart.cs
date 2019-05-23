using Newtonsoft.Json;
using System;
using VirtualMarket.Common.Messages;

namespace VirtualMarket.Services.Operations.Messages.Customers.Commands
{
    [MessageNamespace("customers")]
    public class ClearCart : ICommand
    {
        public Guid CustomerId { get; }
        [JsonConstructor]
        public ClearCart(Guid customerId)
        {
            CustomerId = customerId;
        }
    }
}
