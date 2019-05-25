using System;
using VirtualMarket.Common.Types;

namespace VirtualMarket.Services.Storage.Models.Products
{
    public class Product : IIdentifiable
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Vendor { get; set; }
        public decimal Price { get; set; }
    }
}
