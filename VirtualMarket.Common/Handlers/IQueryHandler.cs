using System.Threading.Tasks;
using VirtualMarket.Common.Types;

namespace VirtualMarket.Common.Handlers
{
    public interface IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
        Task<TResult> HandleAsync(IQuery query);
    }
}
