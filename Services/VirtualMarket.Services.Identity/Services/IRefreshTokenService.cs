using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VirtualMarket.Common.Authentication;

namespace VirtualMarket.Services.Identity.Services
{
    public interface IRefreshTokenService
    {
        Task AddAsync(Guid userId);
        Task<JsonWebToken> CreateAccessTokenAsync(string refreshToken);
        Task RevokeAsync(string refreshToken, Guid userId);
    }
}
