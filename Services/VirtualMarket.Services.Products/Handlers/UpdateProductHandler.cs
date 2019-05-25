using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VirtualMarket.Common.Handlers;
using VirtualMarket.Common.RabbitMq;
using VirtualMarket.Common.Types;
using VirtualMarket.Services.Products.Messages.Commands;
using VirtualMarket.Services.Products.Messages.Events;
using VirtualMarket.Services.Products.Repositories;

namespace VirtualMarket.Services.Products.Handlers
{
    public class UpdateProductHandler : ICommandHandler<UpdateProduct>
    {
        private readonly IProductsRepository _productsRepository;
        private readonly IBusPublisher _busPublisher;

        public UpdateProductHandler(
            IProductsRepository productsRepository,
            IBusPublisher busPublisher)
        {
            _productsRepository = productsRepository;
            _busPublisher = busPublisher;
        }

        public async Task HandleAsync(UpdateProduct command, ICorrelationContext context)
        {
            var product = await _productsRepository.GetAsync(command.Id);
            if (product == null)
            {
                throw new VirtualMarketException("product_not_found",
                    $"Product with id: '{command.Id}' was not found.");
            }

            product.SetName(command.Name);
            product.SetDescription(command.Description);
            product.SetVendor(command.Vendor);
            product.SetPrice(command.Price);
            product.SetQuantity(command.Quantity);
            await _productsRepository.UpdateAsync(product);
            await _busPublisher.PublishAsync(new ProductUpdated(command.Id, command.Name,
                command.Description, command.Vendor, command.Price, command.Quantity), context);
        }
    }
}
