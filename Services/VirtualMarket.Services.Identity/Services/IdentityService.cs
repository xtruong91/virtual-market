using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using VirtualMarket.Common.Authentication;
using VirtualMarket.Common.RabbitMq;
using VirtualMarket.Common.Types;
using VirtualMarket.Services.Identity.Domain;
using VirtualMarket.Services.Identity.Messages.Events;
using VirtualMarket.Services.Identity.Repositories;

namespace VirtualMarket.Services.Identity.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IJwtHandler _jwtHandler;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly IClaimsProvider _claimsProvider;
        private readonly IBusPublisher _busPublisher;
        public IdentityService(IUserRepository userRepository,
            IPasswordHasher<User> passwordHasher, IJwtHandler jwtHandler,
            IRefreshTokenRepository refreshRepository, IClaimsProvider claimsProvider,
            IBusPublisher busPublisher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _jwtHandler = jwtHandler;
            _refreshTokenRepository = refreshRepository;
            _claimsProvider = claimsProvider;
            _busPublisher = busPublisher;
        }
        public Task ChangePasswordAsync(Guid userId, string currentPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public async Task<JsonWebToken> SignInAsync(string email, string password)
        {
            var user = await _userRepository.GetAsync(email);
            if (user == null || !user.ValidatePassword(password, _passwordHasher))
            {
                throw new VirtualMarketException(Codes.InvalidCredential,
                    "Invalid credentials.");
            }
            var refreshToken = new RefreshToken(user, _passwordHasher);
            var claims = await _claimsProvider.GetAsync(user.Id);
            var jwt = _jwtHandler.CreateToken(user.Id.ToString("N"), user.Role, claims);
            jwt.RefreshToken = refreshToken.Token;
            await _refreshTokenRepository.AddAsync(refreshToken);
            return jwt;
        }

        public async Task SignUpAsync(Guid id, string email, string password, string role = "user")
        {
            var user = await _userRepository.GetAsync(email);
            if (user != null)
            {
                throw new VirtualMarketException(Codes.EmailInUse,
                    $"Email: '{email}'  is already in use");
            }
            if (string.IsNullOrWhiteSpace(role))
            {
                role = Role.User;
            }
            user = new User(id, email, role);
            user.SetPassword(password, _passwordHasher);
            await _userRepository.AddAsync(user);
            await _busPublisher.PublishAsync(new SignedUp(id, email, role), CorrelationContext.Empty);
        }
    }
}
