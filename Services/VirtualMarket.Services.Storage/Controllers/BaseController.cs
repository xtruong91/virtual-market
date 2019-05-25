using Microsoft.AspNetCore.Mvc;
using VirtualMarket.Common.Types;

namespace VirtualMarket.Services.Storage.Controllers
{
    [Route("[Controller]")]
    public abstract class BaseController : Controller
    {
        protected IActionResult Single<T>(T model)
        {
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        protected IActionResult Collection<T>(PagedResult<T> pagedResult)
        {
            if (pagedResult == null)
            {
                return NotFound();
            }

            return Ok(pagedResult);
        }
    }
}
