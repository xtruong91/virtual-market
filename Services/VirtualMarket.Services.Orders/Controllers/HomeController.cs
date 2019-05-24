using Microsoft.AspNetCore.Mvc;

namespace VirtualMarket.Services.Orders.Controllers
{
    [Route("")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() => Ok("DShop Orders Service");
    }
}
