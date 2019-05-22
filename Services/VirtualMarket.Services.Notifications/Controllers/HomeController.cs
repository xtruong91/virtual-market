using Microsoft.AspNetCore.Mvc;

namespace VirtualMarket.Services.Notifications.Controllers
{
    [Route("")]
    public class HomeController : ControllerBase
    {
        public IActionResult Get() => Ok("Virtual market notification services");
    }
}
