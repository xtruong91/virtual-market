using RestEase;
using System;
using System.Threading.Tasks;
using VirtualMarket.Services.Notifications.Dto;

namespace VirtualMarket.Services.Notifications.Serviecs
{
    public interface ICustomersService
    {
        [AllowAnyStatusCode]
        [Get("customers/{id}")]
        Task<CustomerDto> GetAsync([Path] Guid id);
    }
}
