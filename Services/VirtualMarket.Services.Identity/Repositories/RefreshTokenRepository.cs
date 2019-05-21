using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VirtualMarket.Common.Mongo;
using VirtualMarket.Services.Identity.Domain;

namespace VirtualMarket.Services.Identity.Repositories
{
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly IMongoRepository<RefreshToken> _refreshRepository;
        public RefreshTokenRepository(IMongoRepository<RefreshToken> refreshRepository)
        {
            refreshRepository = _refreshRepository;
        }
        public async Task AddAsync(RefreshToken token)
            => await _refreshRepository.UpdateAsync(token);

        public async Task<RefreshToken> GetAsync(string token)
            => await _refreshRepository.GetAsync(x => x.Token == token);

        public async Task UpdateAsync(RefreshToken token)
            => await _refreshRepository.UpdateAsync(token);
    }
}
