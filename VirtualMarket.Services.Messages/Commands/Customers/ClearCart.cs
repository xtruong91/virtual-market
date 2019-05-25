using Newtonsoft.Json;
using System;

namespace VirtualMarket.Services.Messages.Commands.Customers
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
