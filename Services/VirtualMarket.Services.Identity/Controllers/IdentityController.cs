using Microsoft.AspNetCore.Mvc;
using VirtualMarket.Common.Mvc;
using System.Threading.Tasks;
using VirtualMarket.Common.Authentication;
using VirtualMarket.Services.Identity.Messages.Commands;
using VirtualMarket.Services.Identity.Services;

namespace VirtualMarket.Services.Identity.Controllers
{
    [Route("")]
    [ApiController]
    public class IdentityController : BaseController
    {
        private readonly IIdentityService _identityService;
        private readonly IRefreshTokenService _refreshTokenservice;

        public IdentityController(IIdentityService identityService,
            IRefreshTokenService refreshTokenService)
        {
            _identityService = identityService;
            _refreshTokenservice = refreshTokenService;
        }
        [HttpGet("me")]
        [JwtAuth]
        public IActionResult Get() => Content($"Your id:'{Userid:N}'.");

        [HttpPost("sign-up")]
        public async Task<IActionResult> SignUp(SignUp command)
        {
            command.BindId(c => c.Id);
            await _identityService.SignUpAsync(command.Id,
                    command.Email, command.Password, command.Role);

            return NoContent();
        }
        [HttpPost("sign-in")]
        public async Task<IActionResult> SignIn(SignIn command)
            => Ok(await _identityService.SignInAsync(command.Email, command.Password));

        [HttpPut("me/password")]
        [JwtAuth]
        public async Task<IActionResult> ChangePassword(ChangePassword command)
        {
            await _identityService.ChangePasswordAsync(command.Bind(c => c.UserId, Userid).UserId,
                command.CurrentPassword, command.NewPassword);
            return NoContent();
        }
    }
}
