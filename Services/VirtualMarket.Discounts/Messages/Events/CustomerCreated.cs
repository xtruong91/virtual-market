using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using VirtualMarket.Common.Messages;

namespace VirtualMarket.Discounts.Messages.Events
{
    [MessageNamespace("customers")]
    public class CustomerCreated : IEvent
    {
        public Guid Id { get; }
        public string Email { get; }

        [JsonConstructor]
        public CustomerCreated(Guid id, string email)
        {
            Id = id;
            Email = email;
        }
    }
}
