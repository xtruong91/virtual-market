﻿using System;
using VirtualMarket.Common.Types;

namespace VirtualMarket.Services.Orders.Domain
{
    public class Customer : IIdentifiable
    {
        public Guid Id { get; private set; }
        public string Email { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Address { get; private set; }
        public string Country { get; private set; }
        public Customer(Guid id, string email, string firstName, string lastName,
            string address, string country)
        {
            Id = id;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            Country = country;
        }
    }
}
