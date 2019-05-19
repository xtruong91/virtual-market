using System;
using System.Threading.Tasks;
using VirtualMarket.Discounts.Domain;

namespace VirtualMarket.Discounts.Repositories
{
    public interface ICustomersRepository
    {
        Task<Customer> GetAsync(Guid id);
        Task AddAsync(Customer customer);
    }
}
