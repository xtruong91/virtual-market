using Microsoft.AspNetCore.Mvc;

namespace VirtualMarket.Services.SignalR.Controllers
{
    [Route("")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() => Ok("Virtual Market Single R Service");
    }
}
