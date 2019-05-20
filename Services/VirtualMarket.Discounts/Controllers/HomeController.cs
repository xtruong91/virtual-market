using Microsoft.AspNetCore.Mvc;

namespace VirtualMarket.Discounts.Controllers
{
    [Route("")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() => Ok("Virtual Market discount service");

        [HttpGet("ping")]
        public IActionResult Ping() => Ok();
    }
}
