using System.Threading.Tasks;
using VirtualMarket.Common.Messages;
using VirtualMarket.Common.RabbitMq;

namespace VirtualMarket.Common.Handlers
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        Task HandleAsync(TCommand command, ICorrelationContext context); 
    }
}
