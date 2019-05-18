using System;
using System.Threading.Tasks;
using VirtualMarket.Services.Customers.Domain;

namespace VirtualMarket.Services.Customers.Repositories
{
    public interface IProductsRepository
    {
        Task<Product> GetAsync(Guid id);
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(Guid id);
    }
}
