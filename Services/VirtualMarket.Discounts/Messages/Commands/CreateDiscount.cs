using Newtonsoft.Json;
using System;
using VirtualMarket.Common.Messages;

namespace VirtualMarket.Discounts.Messages.Commands
{
    public class CreateDiscount : ICommand
    {
        public Guid Id { get; }
        public Guid CustomerId { get; }
        public string Code { get; }
        public double Percentage { get; }

        [JsonConstructor]
        public CreateDiscount(Guid id, Guid customerId,
            string code, double percentage)
        {
            Id = id;
            CustomerId = customerId;
            Code = code;
            Percentage = percentage;
        }
    }
}
