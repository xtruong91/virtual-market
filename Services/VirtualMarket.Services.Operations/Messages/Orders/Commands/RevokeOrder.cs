using Newtonsoft.Json;
using System;
using VirtualMarket.Common.Messages;

namespace VirtualMarket.Services.Operations.Messages.Orders.Commands
{
    [MessageNamespace("orders")]
    public class RevokeOrder : ICommand
    {
        public Guid Id { get; }
        public Guid CustomerId { get; }
        [JsonConstructor]
        public RevokeOrder(Guid id, Guid customerId)
        {
            Id = id;
            CustomerId = customerId;
        }
    }
}
