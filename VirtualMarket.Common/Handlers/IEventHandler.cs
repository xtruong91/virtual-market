using System.Threading.Tasks;
using VirtualMarket.Common.Messages;
using VirtualMarket.Common.RabbitMq;

namespace VirtualMarket.Common.Handlers
{
    public interface IEventHandler<in TEvent> where TEvent : IEvent
    {
        Task HandleAsync(TEvent @event, ICorrelationContext context);
    }
}
