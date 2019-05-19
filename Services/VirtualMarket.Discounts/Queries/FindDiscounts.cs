using System;
using System.Collections.Generic;
using VirtualMarket.Common.Types;
using VirtualMarket.Discounts.Dto;

namespace VirtualMarket.Discounts.Queries
{
    public class FindDiscounts : IQuery<IEnumerable<DiscountDto>>
    {
        public Guid CustomerId { get; set; }
    }
}
