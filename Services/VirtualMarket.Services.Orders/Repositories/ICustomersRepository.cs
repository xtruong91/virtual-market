using System;
using System.Threading.Tasks;
using VirtualMarket.Services.Orders.Domain;

namespace VirtualMarket.Services.Orders.Repositories
{
    public interface ICustomersRepository
  {
        Task<Customer> GetAsync(Guid id);
        Task AddAsync(Customer customer);
  }
}
