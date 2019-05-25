using Microsoft.AspNetCore.Mvc;

namespace VirtualMarket.Services.Products.Controllers
{
    public class HomeController : ControllerBase
  {
        [HttpGet]
        public IActionResult Get() => Ok("Virtual Market products services");
  }
}
