using System.Threading.Tasks;
using VirtualMarket.Common.Messages;

namespace VirtualMarket.Common.Dispatchers
{
    public interface ICommandDispatcher
    {
        Task SendAsync<T>(T Command) where T : ICommand;
    }
}
