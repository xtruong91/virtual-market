using System;
using VirtualMarket.Common.Types;

namespace VirtualMarket.Services.Orders.Domain
{
    public class OrderItem : IIdentifiable
  {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }
        public decimal TotalPrice => Quantity * UnitPrice;
        public OrderItem(Guid id, string name, int quantity, decimal unitPrice)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }
  }
}
