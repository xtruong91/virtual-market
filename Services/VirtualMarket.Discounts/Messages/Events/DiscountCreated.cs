using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using VirtualMarket.Common.Messages;

namespace VirtualMarket.Discounts.Messages.Events
{
    public class DiscountCreated : IEvent
    {
        public Guid Id { get; }
        public Guid CustomerId { get; }
        public string Code { get; }
        public double Percentage { get; }

        [JsonConstructor]
        public DiscountCreated(Guid id, Guid customerId
            , string code, double percentage)
        {
            Id = id;
            CustomerId = customerId;
            Code = code;
            Percentage = percentage;
        }
    }
}
