using Newtonsoft.Json;
using System;
using VirtualMarket.Common.Messages;

namespace VirtualMarket.Services.Orders.Messages.Commands
{
    [MessageNamespace("order")]
    public class RevokeOrder : ICommand
    {
        public Guid Id { get; }
        public Guid CustomerId { get; }
        [JsonConstructor]
        public RevokeOrder(Guid id, Guid customerId)
            => (Id, CustomerId) = (id, customerId);
    }
}
