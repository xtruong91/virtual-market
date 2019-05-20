using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VirtualMarket.Common.Handlers;
using VirtualMarket.Common.RabbitMq;
using VirtualMarket.Services.SignalR.Messages.Events;
using VirtualMarket.Services.SignalR.Services;

namespace VirtualMarket.Services.SignalR.Handlers
{
    public class OperationUpdatedHandler : IEventHandler<OperationPending>,
        IEventHandler<OperationCompleted>, IEventHandler<OperationRejected>
    {
        private readonly IHubService _hubService;
        public OperationUpdatedHandler(IHubService hubService)
        {
            _hubService = hubService;
        }

        public async Task HandleAsync(OperationPending @event, ICorrelationContext context)
            => await _hubService.PublishOperationPendingAsync(@event);

        public async Task HandleAsync(OperationCompleted @event, ICorrelationContext context)
            => await _hubService.PublishOperationCompletedAsync(@event);

        public async Task HandleAsync(OperationRejected @event, ICorrelationContext context)
            => await _hubService.PublishOperationRejectedAsync(@event);
    }
}
