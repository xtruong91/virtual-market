using System;
using VirtualMarket.Common.Types;
using VirtualMarket.Services.Customers.Dto;

namespace VirtualMarket.Services.Customers.Queries
{
    public class GetCart : IQuery<CartDto>
    {
        public Guid Id { get; set; }
    }
}
