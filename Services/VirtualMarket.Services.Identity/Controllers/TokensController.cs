using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VirtualMarket.Common.Mvc;
using VirtualMarket.Common.Authentication;
using VirtualMarket.Services.Identity.Messages.Commands;
using VirtualMarket.Services.Identity.Services;
using Microsoft.AspNetCore.Authorization;

namespace VirtualMarket.Services.Identity.Controllers
{
    [Route("")]
    [ApiController]
    [JwtAuth]
    public class TokensController : BaseController
    {
        private readonly IAccessTokenService _accessTokenService;
        private readonly IRefreshTokenService _refreshTokenService;
        public TokensController(IAccessTokenService accessTokenService,
            IRefreshTokenService refreshTokenService)
        {
            _accessTokenService = accessTokenService;
            _refreshTokenService = refreshTokenService;
        }

        [HttpPost("access-token/{refreshToken}/refresh")]
        [AllowAnonymous]
        public async Task<IActionResult> RefreshAccessToken(string refreshToken,
            RefreshAccessToken command)
            => Ok(await _refreshTokenService.CreateAccessTokenAsync(command.Bind(c => c.Token, refreshToken).Token));

        [HttpPost("access-token/revoke")]
        public async Task<IActionResult> RevokeAccessToken(RevokeAccessToken command)
        {
            await _accessTokenService.DeactiveCurrentAsync(
                command.Bind(c => c.UserId, Userid).UserId.ToString("N"));
            return NoContent();
        }
        [HttpPost("access-tokens/{refreshToken}/revoke")]
        public async Task<IActionResult> RevokeRefreshToken(string refreshToken, RevokeRefreshToken command)
        {
            await _refreshTokenService.RevokeAsync(command.Bind(c => c.Token, refreshToken).Token,
                command.Bind(c => c.UserId, Userid).UserId);
            return NoContent();
        }
    }
}
