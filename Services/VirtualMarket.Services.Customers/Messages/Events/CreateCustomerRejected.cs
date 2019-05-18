using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualMarket.Services.Customers.Messages.Events
{
    public class CreateCustomerRejected
    {
        public Guid Id { get; }
        public string Reason { get; }
        public string Code { get; }

        public CreateCustomerRejected(Guid id, string reason, string code)
        {
            Id = id;
            Reason = reason;
            Code = code;
        }
    }
}
