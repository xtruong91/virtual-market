﻿using Newtonsoft.Json;
using System;

namespace VirtualMarket.Services.Messages.Commands.Orders
{
    public class CreateOrder : ICommand
    {
        public Guid Id { get; }
        public Guid CustomerId { get; }

        [JsonConstructor]
        public CreateOrder(Guid id, Guid customerId)
        {
            Id = id;
            CustomerId = customerId;
        }
    }
}
