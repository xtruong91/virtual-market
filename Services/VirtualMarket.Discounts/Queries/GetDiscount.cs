using System;
using VirtualMarket.Common.Types;
using VirtualMarket.Discounts.Dto;

namespace VirtualMarket.Discounts.Queries
{
    public class GetDiscount : IQuery<DiscountDetailsDto>
    {
        public Guid Id { get; set; }
    }
}
