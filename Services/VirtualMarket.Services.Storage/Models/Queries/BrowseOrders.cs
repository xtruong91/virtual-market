using System;
using VirtualMarket.Common.Types;

namespace VirtualMarket.Services.Storage.Models.Queries
{
    public class BrowseOrders : PagedQueryBase
    {
        public Guid CustomerId { get; set; }
    }
}
