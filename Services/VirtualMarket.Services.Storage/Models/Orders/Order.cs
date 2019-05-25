using System;
using System.Collections.Generic;
using VirtualMarket.Common.Types;

namespace VirtualMarket.Services.Storage.Models.Orders
{
    public class Order : IIdentifiable
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public long Number { get; set; }
        public IEnumerable<Guid> ProductIds { get; set; }
        public decimal TotalAmount { get; set; }
        public string Currency { get; set; }
        public OrderStatus Status { get; set; }

        public enum OrderStatus : byte
        {
            Created = 0,
            Completed = 1,
            Canceled = 2,
        }
    }
}
