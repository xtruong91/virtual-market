using Newtonsoft.Json;
using System;
using VirtualMarket.Common.Messages;

namespace VirtualMarket.Services.Orders.Messages.Commands
{
    [MessageNamespace("order")]
    public class CreateOrderDiscount : ICommand
    {
        public Guid Id { get; }
        public int Percentage { get; }
        public Guid CustomerId { get; }
        [JsonConstructor]
        public CreateOrderDiscount(Guid id, Guid customerId, int percentage)
            => (Id, CustomerId, Percentage) = (id, customerId, percentage);
    }
}
