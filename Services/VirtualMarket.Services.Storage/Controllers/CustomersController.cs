using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using VirtualMarket.Services.Storage.Models.Queries;
using VirtualMarket.Services.Storage.Repositories;

namespace VirtualMarket.Services.Storage.Controllers
{
    public class CustomersController : BaseController
    {
        private readonly ICustomersRepository _repository;

        public CustomersController(ICustomersRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] BrowseCustomers query)
            => Collection(await _repository.BrowseAsync(query));

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
            => Single(await _repository.GetAsync(id));
    }
}
