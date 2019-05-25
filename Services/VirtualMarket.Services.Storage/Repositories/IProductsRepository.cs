using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using VirtualMarket.Common.Types;
using VirtualMarket.Services.Storage.Models.Products;
using VirtualMarket.Services.Storage.Models.Queries;

namespace VirtualMarket.Services.Storage.Repositories
{
    public interface IProductsRepository
    {
        Task<Product> GetAsync(Guid id);
        Task<IEnumerable<Product>> FindAsync(Expression<Func<Product, bool>> predicate);
        Task<PagedResult<Product>> BrowseAsync(BrowseProducts query);
        Task CreateAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(Guid id);
    }
}
