using System.Threading.Tasks;
using VirtualMarket.Common.Mongo;
using VirtualMarket.Discounts.Domain;

namespace VirtualMarket.Discounts.Repositories
{
    public class DiscountsRepository : IDiscountsRepository
    {
        private readonly IMongoRepository<Discount> _repository;

        public DiscountsRepository(IMongoRepository<Discount> repository)
        {
            _repository = repository;
        }
        public async Task AddAsync(Discount discount)
            => await _repository.AddAsync(discount);

        public async Task UpdateAsync(Discount discount)
            => await _repository.UpdateAsync(discount);
    }
}
