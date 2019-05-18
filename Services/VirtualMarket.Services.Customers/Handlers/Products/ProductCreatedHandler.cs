using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VirtualMarket.Common.Handlers;
using VirtualMarket.Common.RabbitMq;
using VirtualMarket.Services.Customers.Domain;
using VirtualMarket.Services.Customers.Messages.Events;
using VirtualMarket.Services.Customers.Repositories;

namespace VirtualMarket.Services.Customers.Handlers.Products
{
    public class ProductCreatedHandler : IEventHandler<ProductCreated>
    {
        private readonly IProductsRepository _productsRepository;

        public ProductCreatedHandler(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public async Task HandleAsync(ProductCreated @event, ICorrelationContext context)
        {
            var product = new Product(@event.Id, @event.Name,
                @event.Price, @event.Quantity);
            await _productsRepository.AddAsync(product);
        }
    }
}
