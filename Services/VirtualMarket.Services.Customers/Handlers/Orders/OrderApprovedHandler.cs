using System.Threading.Tasks;
using VirtualMarket.Common.Handlers;
using VirtualMarket.Common.RabbitMq;
using VirtualMarket.Services.Customers.Messages.Events;
using VirtualMarket.Services.Customers.Repositories;

namespace VirtualMarket.Services.Customers.Handlers.Orders
{
    public class OrderApprovedHandler : IEventHandler<OrderApproved>
    {
        private readonly IProductsRepository _productsRepository;
        private readonly ICartsRepository _cartsRepository;

        public OrderApprovedHandler(ICartsRepository cartsRepository,
            IProductsRepository productsRepository)
        {
            _cartsRepository = cartsRepository;
            _productsRepository = productsRepository;
        }

        public async Task HandleAsync(OrderApproved @event, ICorrelationContext context)
        {
            var cart = await _cartsRepository.GetAsync(@event.CustomerId);
            foreach (var cartItem in cart.Items)
            {
                var product = await _productsRepository.GetAsync(cartItem.ProductId);
                if (product == null)
                {
                    continue;
                }
                product.SetQuantity(product.Quantity - cartItem.Quantity);
                await _productsRepository.UpdateAsync(product);
            }
        }
    }
}
