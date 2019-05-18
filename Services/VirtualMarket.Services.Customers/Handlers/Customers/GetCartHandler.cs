using System;
using System.Linq;
using System.Threading.Tasks;
using VirtualMarket.Common.Handlers;
using VirtualMarket.Common.Types;
using VirtualMarket.Services.Customers.Dto;
using VirtualMarket.Services.Customers.Queries;
using VirtualMarket.Services.Customers.Repositories;

namespace VirtualMarket.Services.Customers.Handlers.Customers
{
    public class GetCartHandler : IQueryHandler<GetCart, CartDto>
    {
        private readonly ICartsRepository _cartsRepository;

        public GetCartHandler(ICartsRepository cartsRerpository)
        {
            _cartsRepository = cartsRerpository;
        }
        public async Task<CartDto> HandleAsync(IQuery query)
        {
            var cart = await _cartsRepository.GetAsync((query as GetCart).Id);

            return cart == null ? null : new CartDto()
            {
                Id = cart.Id,
                Items = cart.Items.Select(x => new CartItemDto
                {
                    ProductId = x.ProductId,
                    ProductName = x.ProductName,
                    Quantity = x.Quantity,
                    UnitPrice = x.UnitPrice
                })
            };
        }
    }
}
