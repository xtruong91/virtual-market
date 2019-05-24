using RestEase;
using System;
using System.Threading.Tasks;
using VirtualMarket.Services.Orders.Dto;

namespace VirtualMarket.Services.Orders.Services
{
    public interface ICustomersService
    {
        [AllowAnyStatusCode]
        [Get("carts/{id}")]
        Task<CartDto> GetCartAsync([Path] Guid id);
    }
}
