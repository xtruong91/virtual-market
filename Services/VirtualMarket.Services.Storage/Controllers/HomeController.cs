using Microsoft.AspNetCore.Mvc;

namespace VirtualMarket.Services.Storage.Controllers
{
    public class HomeController : BaseController
    {
        [HttpGet]
        public IActionResult Get() => Ok("DShop Storage Service");
    }
}
