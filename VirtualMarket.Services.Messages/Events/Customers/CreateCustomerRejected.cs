﻿using Newtonsoft.Json;
using System;

namespace VirtualMarket.Services.Messages.Events.Customers
{
    public class CreateCustomerRejected : IRejectedEvent
    {
        public Guid Id { get; }
        public string Reason { get; }
        public string Code { get; }

        [JsonConstructor]
        public CreateCustomerRejected(Guid id, string reason, string code)
        {
            Id = id;
            Reason = reason;
            Code = code;
        }
    }
}
