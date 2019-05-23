using System.Threading.Tasks;
using VirtualMarket.Common.RabbitMq;

namespace VirtualMarket.Services.Operations.Services
{
    public interface IOperationPublisher
    {
        Task PendingAsync(ICorrelationContext context);
        Task CompleteAsync(ICorrelationContext context);
        Task RejectAsync(ICorrelationContext context, string code, string message);
    }
}
