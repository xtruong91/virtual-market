using RestEase;
using System;
using System.Threading.Tasks;
using VirtualMarket.Discounts.Dto;

namespace VirtualMarket.Discounts.Services
{
    public interface IOrderService
    {
        [AllowAnyStatusCode]
        [Get("orders/{id}")]
        Task<OrderDetailsDto> GetAsync([Path] Guid id);
    }
}
