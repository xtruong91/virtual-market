using System;
using System.Threading.Tasks;
using VirtualMarket.Common.Types;
using VirtualMarket.Services.Products.Domain;
using VirtualMarket.Services.Products.Queries;

namespace VirtualMarket.Services.Products.Repositories
{
    public interface IProductsRepository
    {
        Task<Product> GetAsync(Guid id);
        Task<bool> ExistsAsync(Guid id);
        Task<bool> ExistsAsync(string name);
        Task<PagedResult<Product>> BrowseAsync(BrowseProducts query);
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(Guid id);
    }
}
