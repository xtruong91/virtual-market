using System;
using VirtualMarket.Common.Messages;

namespace VirtualMarket.Services.Customers.Messages.Events
{
    public class CustomerCreated : IEvent
    {
        public Guid Id { get; }
        public string Email { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Address { get; }
        public string Country { get; }
        public CustomerCreated(Guid id, string email, string firstName,
            string lastName, string address, string country)
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
