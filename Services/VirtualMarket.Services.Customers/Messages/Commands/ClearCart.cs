using Newtonsoft.Json;
using System;
using VirtualMarket.Common.Messages;

namespace VirtualMarket.Services.Customers.Messages.Commands
{
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
