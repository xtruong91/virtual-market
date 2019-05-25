using RestEase;
using System;
using System.Threading.Tasks;
using VirtualMarket.Services.Storage.Models.Customers;

namespace VirtualMarket.Services.Storage.ServiceForwarders
{
    public interface ICustomersService
  {
        [Get("/customers/{id}")]
        Task<Customer> GetByIdAsync([Path] Guid id);
    }
}
