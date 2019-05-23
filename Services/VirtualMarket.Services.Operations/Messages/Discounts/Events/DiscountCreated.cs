using Newtonsoft.Json;
using System;
using VirtualMarket.Common.Messages;

namespace VirtualMarket.Services.Operations.Messages.Discounts.Events
{
    [MessageNamespace("discounts")]
    public class DiscountCreated : IEvent
    {
        public Guid Id { get; }
        public Guid CustomerId { get; }
        public string Code { get; }
        public double Percentage { get; }
        [JsonConstructor]
        public DiscountCreated(Guid id, Guid customerId, string code, double percentage)
        {
            Id = id;
            CustomerId = customerId;
            Code = code;
            Percentage = percentage;
        }
    }
}
