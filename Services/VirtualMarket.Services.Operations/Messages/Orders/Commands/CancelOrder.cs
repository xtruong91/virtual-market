using Newtonsoft.Json;
using System;
using VirtualMarket.Common.Messages;

namespace VirtualMarket.Services.Operations.Messages.Orders.Commands
{
    [MessageNamespace("orders")]
    public class CancelOrder : ICommand
    {
        public Guid Id { get; }
        public Guid CustomerId { get; }
        [JsonConstructor]
        public CancelOrder(Guid id, Guid customerId)
        {
            Id = id;
            CustomerId = customerId;
        }
    }
}
