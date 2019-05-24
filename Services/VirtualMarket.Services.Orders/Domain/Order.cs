using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VirtualMarket.Common.Types;

namespace VirtualMarket.Services.Orders.Domain
{
    public class Order : BaseEntity
    {
        public Guid CustomerId { get; private set; }
        public IEnumerable<OrderItem> Items { get; private set; }
        public decimal TotalAmount { get; private set; }
        public string Currency { get; private set; }
        public OrderStatus Status { get; private set; }

        public Order(Guid id, Guid customerId, IEnumerable<OrderItem> items, string currency)
            : base(id)
        {
            if (items == null || !items.Any())
            {
                throw new VirtualMarketException(Codes.CannotCreate,
                    $"Cannot create an order for an empty cart for customer with id:'{customerId}'.");
            }
            if (string.IsNullOrWhiteSpace(currency))
            {
                throw new VirtualMarketException(Codes.InvalidCurrency,
                $"Cannot create an order with invalid currency for customer with id:'{customerId}'.");
            }
            CustomerId = customerId;
            Items = items;
            Currency = currency;
            Status = OrderStatus.Created;
            TotalAmount = Items.Sum(i => i.TotalPrice);
        }
        public enum OrderStatus : byte
        {
            Created = 0,
            Approved,
            Completed,
            Canceled,
            Revoked
        }
    }
}
