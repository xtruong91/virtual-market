using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VirtualMarket.Common.Handlers;
using VirtualMarket.Common.Mongo;
using VirtualMarket.Common.Types;
using VirtualMarket.Discounts.Domain;
using VirtualMarket.Discounts.Dto;
using VirtualMarket.Discounts.Queries;

namespace VirtualMarket.Discounts.Handlers.Discounts
{
    public class GetDiscountHandler : IQueryHandler<GetDiscount, DiscountDetailsDto>
    {
        private readonly IMongoRepository<Discount> _discountsRepository;
        private readonly IMongoRepository<Customer> _customersRepository;

        public GetDiscountHandler(IMongoRepository<Discount> discountsRepository,
            IMongoRepository<Customer> customersRepository)
        {
            _discountsRepository = discountsRepository;
            _customersRepository = customersRepository;
        }

        public async Task<DiscountDetailsDto> HandleAsync(IQuery query)
        {
            throw new NotImplementedException();
        }
    }
}
