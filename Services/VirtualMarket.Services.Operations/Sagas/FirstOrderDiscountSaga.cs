using Chronicle;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VirtualMarket.Common.RabbitMq;
using VirtualMarket.Services.Operations.Messages.Customers.Events;
using VirtualMarket.Services.Operations.Messages.Orders.Commands;
using VirtualMarket.Services.Operations.Messages.Orders.Events;

namespace VirtualMarket.Services.Operations.Sagas
{
    public class FirstOrderDiscountSagaState
    {
        public DateTime CustomerCreatedAt { get; set; }
    }
    public class FirstOrderDiscountSaga : Saga<FirstOrderDiscountSagaState>,
        ISagaStartAction<CustomerCreated>,
        ISagaStartAction<OrderCreated>
    {
        private const int CreationHoursLimit = 24;
        private readonly IBusPublisher _busPublisher;
        
        public FirstOrderDiscountSaga(IBusPublisher busPublisher)
        {
            _busPublisher = busPublisher;
        }
        public override Guid ResolveId(object message, ISagaContext context)
        {
            switch (message)
            {
                case CustomerCreated cc: return cc.Id;
                case OrderCreated cc: return cc.CustomerId;
                default: return base.ResolveId(message, context);
            }            
        }
        public async Task CompensateAsync(CustomerCreated message, ISagaContext context)
        {
            Data.CustomerCreatedAt = DateTime.UtcNow;
            await Task.CompletedTask;
        }

        public async Task CompensateAsync(OrderCreated message, ISagaContext context)
        {
            var diff = DateTime.UtcNow.Subtract(Data.CustomerCreatedAt);
            if (diff.TotalHours <= CreationHoursLimit)
            {
                await _busPublisher.SendAsync(new CreateOrderDiscount(
                    message.Id, message.CustomerId, 10), CorrelationContext.Empty);
                Complete();
            }
            else
            {
                Reject();
            }
        }

        public async Task HandleAsync(CustomerCreated message, ISagaContext context)
        {
            await Task.CompletedTask;
        }

        public async Task HandleAsync(OrderCreated message, ISagaContext context)
        {
            await Task.CompletedTask;
        }
    }
}
