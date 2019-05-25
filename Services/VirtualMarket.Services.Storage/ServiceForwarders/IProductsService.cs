using RestEase;
using System;
using System.Threading.Tasks;
using VirtualMarket.Services.Storage.Models.Products;

namespace VirtualMarket.Services.Storage.ServiceForwarders
{
    public interface IProductsService
    {
        [Get("/products/{id}")]
        Task<Product> GetProductByIdAsync([Path] Guid id);
    }
}
