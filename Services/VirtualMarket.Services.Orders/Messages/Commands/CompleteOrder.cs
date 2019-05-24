using Newtonsoft.Json;
using System;
using VirtualMarket.Common.Messages;

namespace VirtualMarket.Services.Orders.Messages.Commands
{
    [MessageNamespace("order")]
    public class CompleteOrder : ICommand
    {
        public Guid Id { get; }
        public Guid CustomerId { get; }
        [JsonConstructor]
        public CompleteOrder(Guid id, Guid customerId)
            => (Id, CustomerId) = (id, customerId);
    }
}
