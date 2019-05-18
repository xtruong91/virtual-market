using RestEase;
using System;
using System.Threading.Tasks;
using VirtualMarket.Services.Customers.Dto;

namespace VirtualMarket.Services.Customers.Services
{
    public interface IProductsService
    {
        [AllowAnyStatusCode]
        [Get("products/{id}")]
        Task<ProductDto> GetAsync([Path] Guid id);
    }
}
