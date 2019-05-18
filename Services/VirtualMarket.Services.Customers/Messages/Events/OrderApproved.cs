using System;
using VirtualMarket.Common.Messages;

namespace VirtualMarket.Services.Customers.Messages.Events
{
    [MessageNamespace("orders")]
    public class OrderApproved : IEvent
    {
        public Guid Id { get; }
        public Guid CustomerId { get; }

        public OrderApproved(Guid id, Guid customerId)
        {
            Id = id;
            CustomerId = customerId;
        }
    }
}
