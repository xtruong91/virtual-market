using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualMarket.Common.Handlers;
using VirtualMarket.Common.Mongo;
using VirtualMarket.Common.Types;
using VirtualMarket.Discounts.Domain;
using VirtualMarket.Discounts.Dto;
using VirtualMarket.Discounts.Metrics;
using VirtualMarket.Discounts.Queries;

namespace VirtualMarket.Discounts.Handlers.Discounts
{
    public class FindDiscountsHandler : IQueryHandler<FindDiscounts, IEnumerable<DiscountDto>>
    {
        private readonly IMongoRepository<Discount> _discountsRepository;
        private readonly IMetricsRegistry _registry;

        public FindDiscountsHandler(IMongoRepository<Discount> discountRepository,
            IMetricsRegistry registry)
        {
            _discountsRepository = discountRepository;
            _registry = registry;
        }


        public async Task<IEnumerable<DiscountDto>> HandleAsync(IQuery query)
        {
            _registry.IncrementFindDiscountsQuery();
            var discounts = await _discountsRepository.FindAsync(c =>
                    c.CustomerId == (query as FindDiscounts).CustomerId);

            return discounts.Select(d => new DiscountDto
            {
                Id = d.Id,
                CustomerId = d.CustomerId,
                Code = d.Code,
                Percentage = d.Percentage,
                Available = !d.UsedAt.HasValue           
            });
        }
    }
}
