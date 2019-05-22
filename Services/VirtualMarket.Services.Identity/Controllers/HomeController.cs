using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualMarket.Services.Identity.Controllers
{
    [Route("")]
    public class HomeController : ControllerBase
    {
        public IActionResult Get() => Ok("Virtual market Identity Service");
    }
    
}
