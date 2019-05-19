using System;
using System.Collections.Generic;
using System.Text;
using VirtualMarket.Common.Types;

namespace VirtualMarket.Discounts.Domain
{
    public class Customer : IIdentifiable
    {
        public Guid Id { get; private set; }
        public string Email { get; private set; }
        public Customer(Guid id, string email)
        {
            Id = id;
            Email = email;
        }
    }
}
