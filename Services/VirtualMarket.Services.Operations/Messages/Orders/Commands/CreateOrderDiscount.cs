using Newtonsoft.Json;
using System;
using VirtualMarket.Common.Messages;

namespace VirtualMarket.Services.Operations.Messages.Orders.Commands
{
    [MessageNamespace("orders")]
    public class CreateOrderDiscount : ICommand
    {
        public Guid Id { get; }
        public Guid CustomerId { get; }
        public int Percentage { get; }

        [JsonConstructor]
        public CreateOrderDiscount(Guid id, Guid customerId, int percentage)
        {
            Id = id;
            CustomerId = customerId;
            Percentage = percentage;
        }
    }
}
