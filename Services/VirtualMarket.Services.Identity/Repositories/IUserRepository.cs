using System;
using System.Threading.Tasks;
using VirtualMarket.Services.Identity.Domain;

namespace VirtualMarket.Services.Identity.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetAsync(Guid id);
        Task<User> GetAsync(string email);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
    }
}
