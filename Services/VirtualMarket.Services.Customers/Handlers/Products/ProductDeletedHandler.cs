using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using VirtualMarket.Common.Handlers;
using VirtualMarket.Common.RabbitMq;
using VirtualMarket.Services.Customers.Messages.Events;
using VirtualMarket.Services.Customers.Repositories;

namespace VirtualMarket.Services.Customers.Handlers.Products
{
    public class ProductDeletedHandler : IEventHandler<ProductDeleted>
    {
        private readonly ICartsRepository _cartsRepository;
        private readonly IProductsRepository _productsRepository;

        public ProductDeletedHandler(ICartsRepository cartsRepository,
            IProductsRepository productsRepository)
        {
            _cartsRepository = cartsRepository;
            _productsRepository = productsRepository;
        }

        public async Task HandleAsync(ProductDeleted @event, ICorrelationContext context)
        {
            await _productsRepository.DeleteAsync(@event.Id);
            var carts = await _cartsRepository.GetAllWithProduct(@event.Id)
                .ContinueWith(t => t.Result.ToList());
            foreach (var cart in carts)
            {
                cart.DeleteProduct(@event.Id);
            }

            await _cartsRepository.UpdateManyAsync(carts);
        }
    }
}
