using System;
using VirtualMarket.Common.Types;
using VirtualMarket.Services.Products.Dto;

namespace VirtualMarket.Services.Products.Queries
{
    public class GetProduct : IQuery<ProductDto>
    {
        public Guid Id { get; set; }
    }
}
