using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VirtualMarket.Services.Storage.Models.Queries;
using VirtualMarket.Services.Storage.Repositories;

namespace VirtualMarket.Services.Storage.Controllers
{
    public class OrdersController : BaseController
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly IProductsRepository _productsRepository;
        private readonly ICustomersRepository _customersRepository;

        public OrdersController(
            IOrdersRepository ordersRepository,
            IProductsRepository productsRepository,
            ICustomersRepository customersRepository)
        {
            _ordersRepository = ordersRepository;
            _productsRepository = productsRepository;
            _customersRepository = customersRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] BrowseOrders query)
            => Collection(await _ordersRepository.BrowseAsync(query));

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var order = await _ordersRepository.GetAsync(id);
            var products = await _productsRepository.FindAsync(p => order.ProductIds.Contains(p.Id));
            var customer = await _customersRepository.GetAsync(order.CustomerId);

            var orderDetails = new OrderDetails
            {
                Order = order,
                Products = products,
                Customer = customer
            };

            return Single(orderDetails);
        }
    }
}
