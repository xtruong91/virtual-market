using Chronicle;
using System;
using System.Threading.Tasks;
using VirtualMarket.Common.RabbitMq;
using VirtualMarket.Services.Operations.Messages.Orders.Commands;
using VirtualMarket.Services.Operations.Messages.Orders.Events;
using VirtualMarket.Services.Operations.Messages.Products.Commands;
using VirtualMarket.Services.Operations.Messages.Products.Events;

namespace VirtualMarket.Services.Operations.Sagas
{
    public class ApproveOrderSaga : Saga,
          ISagaStartAction<OrderCreated>,
          ISagaAction<RevokeOrderRejected>,
          ISagaAction<ProductsReserved>,
          ISagaAction<ReserveProductsRejected>,
          ISagaAction<OrderApproved>,
          ISagaAction<ApproveOrderRejected>
    {

        private readonly IBusPublisher _busPublisher;
        public ApproveOrderSaga(IBusPublisher busPublisher)
            => _busPublisher = busPublisher;

        public override Guid ResolveId(object message, ISagaContext context)
        {
            switch (message)
            {
                case OrderCreated m: return m.Id;
                case ProductsReserved m: return m.OrderId;
                case ReserveProductsRejected m: return m.OrderId;
                case OrderApproved m: return m.Id;
                case ApproveOrderRejected m: return m.Id;
                default: return base.ResolveId(message, context);
            }
        }
        public async Task CompensateAsync(OrderCreated message, ISagaContext context)
        {
            await _busPublisher.SendAsync(new ReserveProducts(message.Id, message.Products), CorrelationContext.Empty);
        }

        public async Task CompensateAsync(RevokeOrderRejected message, ISagaContext context)
        {
            Reject();
            await Task.CompletedTask;
        }

        public async Task CompensateAsync(ProductsReserved message, ISagaContext context)
        {
            await _busPublisher.SendAsync(new ReleaseProducts(message.OrderId, message.Products), CorrelationContext.Empty);
        }

        public async Task CompensateAsync(ReserveProductsRejected message, ISagaContext context)
        {
            Reject();
            await Task.CompletedTask;
        }

        public async Task CompensateAsync(OrderApproved message, ISagaContext context)
        {
            await Task.CompletedTask;
        }

        public async Task CompensateAsync(ApproveOrderRejected message, ISagaContext context)
        {
            await Task.CompletedTask;
        }

        public async Task HandleAsync(OrderCreated message, ISagaContext context)
        {
            await _busPublisher.SendAsync(new ReserveProducts(message.Id, message.Products), CorrelationContext.Empty);
        }

        public async Task HandleAsync(RevokeOrderRejected message, ISagaContext context)
        {
            Reject();
            await Task.CompletedTask;
        }

        public async Task HandleAsync(ProductsReserved message, ISagaContext context)
        {
            await _busPublisher.SendAsync(new ApproveOrder(message.OrderId), CorrelationContext.Empty);
        }

        public async Task HandleAsync(ReserveProductsRejected message, ISagaContext context)
        {
            Reject();
            await Task.CompletedTask;
        }

        public async Task HandleAsync(OrderApproved message, ISagaContext context)
        {
            Complete();
            await Task.CompletedTask;
        }

        public async Task HandleAsync(ApproveOrderRejected message, ISagaContext context)
        {
            await Task.CompletedTask;
        }
    }
}
