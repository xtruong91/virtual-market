using System.Collections.Generic;
using VirtualMarket.Services.Storage.Models.Customers;

namespace VirtualMarket.Services.Storage.Models.Orders
{
    public class OrderDetail
    {
        public Order Order { get; set; }
        public Customer Customer { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
