using System.Threading.Tasks;
using VirtualMarket.Common.Types;

namespace VirtualMarket.Common.Dispatchers
{
    public interface IQueryDispatcher
    {
        Task<TResult> QueryAsync<TResult>(IQuery<TResult> query);
    }
}
