using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VirtualMarket.Common.Dispatchers;
using VirtualMarket.Services.Customers.Dto;
using VirtualMarket.Services.Customers.Queries;

namespace VirtualMarket.Services.Customers.Controllers
{
    public class CartsController : BaseController
    {
        public CartsController(IDispatcher dispatcher)
            : base(dispatcher)
        {

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CartDto>> Get([FromRoute] GetCart query)
            => Single(await QueryAsync(query));
    }
}
