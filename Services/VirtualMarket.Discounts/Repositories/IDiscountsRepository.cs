using System.Threading.Tasks;
using VirtualMarket.Discounts.Domain;

namespace VirtualMarket.Discounts.Repositories
{
    public interface IDiscountsRepository
    {
        Task AddAsync(Discount discount);
        Task UpdateAsync(Discount discount);
    }
}
