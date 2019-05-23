using Newtonsoft.Json;
using System;
using VirtualMarket.Common.Messages;

namespace VirtualMarket.Services.Operations.Messages.Orders.Commands
{
    [MessageNamespace("orders")]
    public class CompleteOrder : ICommand
    {
        public Guid Id { get; }
        public Guid CustomerId { get; }
        [JsonConstructor]
        public CompleteOrder(Guid id, Guid customerId)
        {
            Id = id;
            CustomerId = customerId;
        }
    }
}
