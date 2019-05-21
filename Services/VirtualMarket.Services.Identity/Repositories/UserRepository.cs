using System;
using System.Threading.Tasks;
using VirtualMarket.Common.Mongo;
using VirtualMarket.Services.Identity.Domain;

namespace VirtualMarket.Services.Identity.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoRepository<User> _userRepository;
        public UserRepository(IMongoRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task AddAsync(User user)
            => await _userRepository.AddAsync(user);

        public async Task<User> GetAsync(Guid id)
            => await _userRepository.GetAsync(id);

        public async Task<User> GetAsync(string email)
            => await _userRepository.GetAsync(x => x.Email == email.ToLowerInvariant());
        public async Task UpdateAsync(User user)
            => await _userRepository.UpdateAsync(user);
    }
}
