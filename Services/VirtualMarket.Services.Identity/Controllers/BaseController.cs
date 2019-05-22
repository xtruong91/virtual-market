using Microsoft.AspNetCore.Mvc;
using System;

namespace VirtualMarket.Services.Identity.Controllers
{
    public class BaseController : ControllerBase
    {
        protected bool IsAdmin
            => User.IsInRole("admin");
        protected Guid Userid
            => string.IsNullOrWhiteSpace(User?.Identity?.Name) ?
            Guid.Empty :
            Guid.Parse(User.Identity.Name);
    }
}
