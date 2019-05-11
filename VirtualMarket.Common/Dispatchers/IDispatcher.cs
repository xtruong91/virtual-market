using System.Threading.Tasks;
using VirtualMarket.Common.Messages;
using VirtualMarket.Common.Types;

namespace VirtualMarket.Common.Dispatchers
{
    public interface IDispatcher
    {
        Task SendAsync<TCommand>(TCommand command) where TCommand : ICommand;
        Task<TResult> QueryAsync<TResult>(IQuery<TResult> query);
    }
}
