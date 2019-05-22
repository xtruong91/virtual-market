using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using VirtualMarket.Common.Types;

namespace VirtualMarket.Services.Identity.Domain
{
    public class RefreshToken : IIdentifiable
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public string Token { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? RevokedAt { get; private set; }
        public bool Revoked => RevokedAt.HasValue;
        public RefreshToken(User user, IPasswordHasher<User> passwordHasher)
        {
            Id = Guid.NewGuid();
            UserId = user.Id;
            CreatedAt = DateTime.UtcNow;
            Token = CreateToken(user, passwordHasher);
        }

        public void Revoke()
        {
            if (Revoked)
            {
                throw new VirtualMarketException(Codes.RefreshTokenAlreadyRevoked,
                    $"Refresh token: '{Id}' was already revoked at '{RevokedAt}'. ");
            }
            RevokedAt = DateTime.UtcNow;
        }
        private string CreateToken(User user, IPasswordHasher<User> passwordHasher)
            => passwordHasher.HashPassword(user, Guid.NewGuid().ToString("N"))
            .Replace("=", string.Empty)
            .Replace("+", string.Empty)
            .Replace("/", string.Empty);
    }
}
