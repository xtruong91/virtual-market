using Microsoft.AspNetCore.Mvc;

namespace VirtualMarket.Services.Customers.Controllers
{
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() => Ok("Virtual Market Customers Service");
    }
}
