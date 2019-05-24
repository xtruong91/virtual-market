using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VirtualMarket.Common.Dispatchers;
using VirtualMarket.Common.Types;
using VirtualMarket.Services.Orders.Dto;
using VirtualMarket.Services.Orders.Queries;

namespace VirtualMarket.Services.Orders.Controllers
{
    [Route("")]
    public class OrdersController : BaseController
    {
        public OrdersController(IDispatcher dispatcher) : base(dispatcher)
        {
        }

        [HttpGet("orders")]
        public async Task<ActionResult<PagedResult<OrderDto>>> Get([FromQuery] BrowseOrders query)
            => Collection(await QueryAsync(query));

        [HttpGet("orders/{orderId}")]
        public async Task<ActionResult<OrderDetailsDto>> Get([FromRoute] GetOrder query)
            => Single(await QueryAsync(query));

        [HttpGet("customers/{customerId}/orders/{orderId}")]
        public async Task<ActionResult<OrderDetailsDto>> GetForCustomer([FromRoute] GetOrder query)
            => Single(await QueryAsync(query));
    }
}
