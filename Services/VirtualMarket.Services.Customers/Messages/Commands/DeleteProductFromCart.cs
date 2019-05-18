using System;
using System.Collections.Generic;
using System.Text;
using VirtualMarket.Common.Messages;

namespace VirtualMarket.Services.Customers.Messages.Commands
{
    public class DeleteProductFromCart : ICommand
    {
        public Guid CustomerId { get; }
        public Guid ProductId { get; }

        public DeleteProductFromCart(Guid customerId, Guid productId)
        {
            CustomerId = customerId;
            ProductId = productId;
        }
    }
}
