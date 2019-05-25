using System.Threading.Tasks;
using VirtualMarket.Common.Handlers;
using VirtualMarket.Common.RabbitMq;
using VirtualMarket.Common.Types;
using VirtualMarket.Services.Products.Domain;
using VirtualMarket.Services.Products.Messages.Commands;
using VirtualMarket.Services.Products.Messages.Events;
using VirtualMarket.Services.Products.Repositories;

namespace VirtualMarket.Services.Products.Handlers
{
    public class CreateProductHandler : ICommandHandler<CreateProduct>
    {
        private readonly IProductsRepository _productsRepository;
        private readonly IBusPublisher _busPublisher;

        public CreateProductHandler(IProductsRepository productsRepository,
            IBusPublisher busPublisher)
        => (_productsRepository, _busPublisher) = (productsRepository, busPublisher);

        public async Task HandleAsync(CreateProduct command, ICorrelationContext context)
        {
            if (command.Quantity < 0)
            {
                throw new VirtualMarketException("invalid_product_quantity",
                    "Product quantity cannot be negative.");
            }
            if (await _productsRepository.ExistsAsync(command.Name))
            {
                throw new VirtualMarketException("product_already_exits",
                    $"Product:'{command.Name}' already exists.");
            }
            var product = new Product(command.Id, command.Name, command.Description,
                command.Vendor, command.Price, command.Quantity);
            await _productsRepository.AddAsync(product);
            await _busPublisher.PublishAsync(new ProductCreated(command.Id, command.Name, command.Description,
                command.Vendor, command.Price, command.Quantity), context);
        }
    }
}
