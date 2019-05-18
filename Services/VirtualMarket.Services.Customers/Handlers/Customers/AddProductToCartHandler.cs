using System.Threading.Tasks;
using VirtualMarket.Common.Handlers;
using VirtualMarket.Common.RabbitMq;
using VirtualMarket.Common.Types;
using VirtualMarket.Services.Customers.Messages.Commands;
using VirtualMarket.Services.Customers.Messages.Events;
using VirtualMarket.Services.Customers.Repositories;

namespace VirtualMarket.Services.Customers.Handlers.Customers
{
    public class AddProductToCartHandler : ICommandHandler<AddProductToCart>
    {
        private readonly IBusPublisher _busPublisher;
        private readonly ICartsRepository _cartsRepostitory;
        private readonly IProductsRepository _productsRepository;

        public AddProductToCartHandler(IBusPublisher busPublisher,
            ICartsRepository cartsRepository,
            IProductsRepository productsRepository)
        {
            _busPublisher = busPublisher;
            _cartsRepostitory = cartsRepository;
            _productsRepository = productsRepository;
        }

        public async Task HandleAsync(AddProductToCart command, ICorrelationContext context)
        {
            if (command.Quantity <= 0)
            {
                throw new VirtualMarketException(Codes.InvalidQuantity,
                    $"Invalid quantity: '{command.Quantity}'.");
            }
            var product = await _productsRepository.GetAsync(command.ProductId);
            if (product == null)
            {
                throw new VirtualMarketException(Codes.ProductNotFound,
                    $"Product: '{command.ProductId}' was not found.");
            }

            if (product.Quantity < command.Quantity)
            {
                throw new VirtualMarketException(Codes.NotEnoughProductsInStock,
                    $"Not enough products in stock: '{command.ProductId}'.");
            }

            var cart = await _cartsRepostitory.GetAsync(command.CustomerId);
            cart.AddProduct(product, command.Quantity);
            await _cartsRepostitory.UpdateAsync(cart);
            await _busPublisher.PublishAsync(new ProductAddedToCart(command.CustomerId,
                command.ProductId, command.Quantity), context);
        }
    }
}
