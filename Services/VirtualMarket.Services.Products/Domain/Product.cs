using System;
using VirtualMarket.Common.Types;

namespace VirtualMarket.Services.Products.Domain
{
    public class Product : BaseEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Vendor { get; private set; }
        public decimal Price { get; private set; }
        public int Quantity { get; private set; }
        public Product(Guid id, string name, string description, string vendor,
            decimal price, int quantity) : base(id)
        {
            SetName(name);
            SetVendor(vendor);
            SetDescription(description);
            SetPrice(price);
            SetQuantity(quantity);
        }

        public void SetQuantity(int quantity)
        {
            if (quantity <= 0)
            {
                throw new VirtualMarketException("empty_product_name",
                    "Product name cannot be empty");
            }
            Quantity = quantity;
            SetUpdateDate();
        }

        public void SetPrice(decimal price)
        {
            if (price <= 0)
            {
                throw new VirtualMarketException("empty_product_name",
                    "Product name cannot be empty");
            }
            Price = price;
            SetUpdateDate();
        }

        public void SetDescription(string description)
        {
            if (string.IsNullOrEmpty(description))
            {
                throw new VirtualMarketException("empty_product_name",
                    "Product name cannot be empty");
            }
            Name = description.Trim().ToLowerInvariant();
            SetUpdateDate();
        }

        public void SetVendor(string vendor)
        {
            if (string.IsNullOrEmpty(vendor))
            {
                throw new VirtualMarketException("empty_product_name",
                    "Product name cannot be empty");
            }
            Name = vendor.Trim().ToLowerInvariant();
            SetUpdateDate();
        }

        public void SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new VirtualMarketException("empty_product_name",
                    "Product name cannot be empty");
            }
            Name = name.Trim().ToLowerInvariant();
            SetUpdateDate();
        }
    }
}
