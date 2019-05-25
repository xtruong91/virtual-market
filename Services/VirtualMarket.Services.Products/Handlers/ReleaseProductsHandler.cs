using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VirtualMarket.Common.Handlers;
using VirtualMarket.Common.RabbitMq;
using VirtualMarket.Services.Products.Messages.Commands;
using VirtualMarket.Services.Products.Messages.Events;
using VirtualMarket.Services.Products.Repositories;

namespace VirtualMarket.Services.Products.Handlers
{
    public class ReleaseProductsHandler : ICommandHandler<ReleaseProducts>
    {
        private readonly IBusPublisher _busPublisher;
        private readonly IProductsRepository _productsRepository;
        private readonly ILogger<ReleaseProductsHandler> _logger;

        public ReleaseProductsHandler(IBusPublisher busPublisher,
            IProductsRepository productsRepository,
            ILogger<ReleaseProductsHandler> logger)
        {
            _busPublisher = busPublisher;
            _productsRepository = productsRepository;
            _logger = logger;
        }

        public async Task HandleAsync(ReleaseProducts command, ICorrelationContext context)
        {
            foreach ((Guid productId, int quantity) in command.Products)
            {
                _logger.LogInformation($"Releasing a product: '{productId}' ({quantity})");
                var product = await _productsRepository.GetAsync(productId);
                if (product == null)
                {
                    _logger.LogInformation($"Product was not found: '{productId}' (can't release).");

                    continue;
                }

                product.SetQuantity(product.Quantity + quantity);
                await _productsRepository.UpdateAsync(product);
                _logger.LogInformation($"Released a product: '{productId}' ({quantity})");
            }

            await _busPublisher.PublishAsync(new ProductsReleased(command.OrderId,
                command.Products), context);
        }
    }
}
