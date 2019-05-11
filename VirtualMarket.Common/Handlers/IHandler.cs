using System;
using System.Threading.Tasks;
using VirtualMarket.Common.Types;

namespace VirtualMarket.Common.Handlers
{
    public interface IHandler
    {
        IHandler Handle(Func<Task> handle);
        IHandler OnSuccess(Func<Task> onSuccess);
        IHandler OnError(Func<Exception, Task> onError, bool retthrow = false);
        IHandler OnCustomError(Func<VirtualMarketException, Task> onCustomError, bool erthrow = false);
        IHandler Always(Func<Task> always);
        Task ExcecuteAsync();
    }
}
