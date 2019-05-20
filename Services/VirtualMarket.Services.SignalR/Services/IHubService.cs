using System.Threading.Tasks;
using VirtualMarket.Services.SignalR.Messages.Events;

namespace VirtualMarket.Services.SignalR.Services
{
    public interface IHubService
    {
        Task PublishOperationPendingAsync(OperationPending @event);
        Task PublishOperationCompletedAsync(OperationCompleted @event);
        Task PublishOperationRejectedAsync(OperationRejected @event);
    }
}
