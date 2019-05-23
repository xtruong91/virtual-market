using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VirtualMarket.Common.RabbitMq;
using VirtualMarket.Services.Operations.Messages.Operations.Events;

namespace VirtualMarket.Services.Operations.Services
{
    public class OperationsPublisher : IOperationPublisher
    {
        private readonly IBusPublisher _busPublisher;
        public OperationsPublisher(IBusPublisher busPublisher)
        {
            _busPublisher = busPublisher;
        }
        public async Task CompleteAsync(ICorrelationContext context)
         => await _busPublisher.PublishAsync(new OperationCompleted(context.Id,
             context.UserId, context.Name, context.Resource), context);

        public async Task PendingAsync(ICorrelationContext context)
         => await _busPublisher.PublishAsync(new OperationPending(context.Id, context.UserId,
             context.Name, context.Resource), context);

        public async Task RejectAsync(ICorrelationContext context, string code, string message)
        => await _busPublisher.PublishAsync(new OperationRejected(context.Id, context.UserId,
            context.Name, context.Resource, code, message), context);
    }
}
