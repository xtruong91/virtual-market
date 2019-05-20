using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using VirtualMarket.Common.Dispatchers;
using VirtualMarket.Discounts.Dto;
using VirtualMarket.Discounts.Messages.Commands;
using VirtualMarket.Discounts.Queries;
using VirtualMarket.Common.Mvc;

namespace VirtualMarket.Discounts.Controllers
{
    public class DiscountsController : ControllerBase
    {
        private readonly IDispatcher _dispatcher;
        public DiscountsController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DiscountDto>>> Get([FromQuery] FindDiscounts query)
            => Ok(await _dispatcher.QueryAsync(query));
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<DiscountDetailsDto>> Get([FromRoute] GetDiscount query)
        {
            var discount = await _dispatcher.QueryAsync(query);
            if (discount is null)
            {
                return NotFound();
            }
            return discount;
        }

        [HttpPost]
        public async Task<ActionResult> Post(CreateDiscount command)
        {
            await _dispatcher.SendAsync(command.BindId(c => c.Id));
            return Accepted();
        }

    }
}
