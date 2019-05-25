using VirtualMarket.Common.Types;
using VirtualMarket.Services.Products.Dto;

namespace VirtualMarket.Services.Products.Queries
{
    public class BrowseProducts : PagedQueryBase, IQuery<PagedResult<ProductDto>>
    {
        public decimal PriceFrom { get; set; }
        public decimal PriceTo { get; set; } = decimal.MaxValue;
    }
}
