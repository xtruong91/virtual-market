using System;
using VirtualMarket.Common.Types;
using VirtualMarket.Services.Customers.Dto;

namespace VirtualMarket.Services.Customers.Queries
{
    public class GetCustomer : IQuery<CustomerDto>
    {
        public Guid Id { get; set; }
    }
}
