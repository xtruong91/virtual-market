using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using VirtualMarket.Common.Messages;

namespace VirtualMarket.Services.Orders.Messages.Commands
{
    [MessageNamespace("order")]
    public class CreateOrder : ICommand
    {
        public Guid Id { get; }
        public Guid CustomerId { get; }
        [JsonConstructor]
        public CreateOrder(Guid id, Guid customerId)
            => (Id, CustomerId) = (id, customerId);
    }
}
