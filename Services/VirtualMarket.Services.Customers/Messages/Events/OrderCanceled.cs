using System;
using System.Collections.Generic;
using System.Text;
using VirtualMarket.Common.Messages;

namespace VirtualMarket.Services.Customers.Messages.Events
{
    [MessageNamespace("orders")]
    public class OrderCanceled : IEvent
    {
        public Guid Id { get; }
        public Guid CustomerId { get; }
        public OrderCanceled(Guid id, Guid customerId)
        {
            Id = id;
            CustomerId = customerId;
        }
    }
}
