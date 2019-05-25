using RestEase;
using System;
using System.Threading.Tasks;
using VirtualMarket.Services.Storage.Models.Orders;

namespace VirtualMarket.Services.Storage.ServiceForwarders
{
    public interface IOrdersService
    {
        [Get("/orders/{id}")]
        Task<Order> GetByIdAsync([Path] Guid id);
    }
}
