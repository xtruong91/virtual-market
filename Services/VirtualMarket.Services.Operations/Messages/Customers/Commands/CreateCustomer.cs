using Newtonsoft.Json;
using System;
using VirtualMarket.Common.Messages;

namespace VirtualMarket.Services.Operations.Messages.Customers.Commands
{
    [MessageNamespace("customers")]
  public class CreateCustomer : ICommand
  {
        public Guid Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Address { get; }
        public string Country { get; }

        [JsonConstructor]
        public CreateCustomer(Guid id, string firstName, string lastName,
            string address, string country)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            Country = country;
        }
  }
}
