using System;
using System.Collections.Generic;
using System.Text;
using VirtualMarket.Common.Types;
using VirtualMarket.Services.Customers.Dto;

namespace VirtualMarket.Services.Customers.Queries
{
  public class BrowseCustomers : PagedQueryBase, IQuery<PagedResult<CustomerDto>>
  {

  }
}
