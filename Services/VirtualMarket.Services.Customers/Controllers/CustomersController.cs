using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VirtualMarket.Common.Dispatchers;
using VirtualMarket.Common.Types;
using VirtualMarket.Services.Customers.Dto;
using VirtualMarket.Services.Customers.Queries;

namespace VirtualMarket.Services.Customers.Controllers
{
    public class CustomersController : BaseController
    {
        public CustomersController(IDispatcher dispatcher)
            : base(dispatcher)
        {

        }
        [HttpGet]
        public async Task<ActionResult<PagedResult<CustomerDto>>> Get([FromQuery] BrowseCustomers query)
            => Collection(await QueryAsync(query));
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDto>> Get([FromRoute] GetCustomer query)
            => Single(await QueryAsync(query));

    }
}
