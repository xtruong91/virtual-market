﻿using System;

namespace VirtualMarket.Services.Customers.Dto
{
    public class CustomerDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Completed { get; set; }
    }
}
