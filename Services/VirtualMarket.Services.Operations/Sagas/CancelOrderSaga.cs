﻿using Chronicle;
using System.Threading.Tasks;
using VirtualMarket.Common.RabbitMq;
using VirtualMarket.Services.Operations.Messages.Orders.Events;
using VirtualMarket.Services.Operations.Messages.Products.Commands;
using VirtualMarket.Services.Operations.Messages.Products.Events;

namespace VirtualMarket.Services.Operations.Sagas
{
    public class CancelOrderSaga : Saga,
          ISagaStartAction<OrderCanceled>,
          ISagaAction<CancelOrderRejected>,
          ISagaAction<ProductsReleased>,
          ISagaAction<ReleaseProductsRejected>
    {
        private readonly IBusPublisher _busPublisher;

        public CancelOrderSaga(IBusPublisher busPublisher)
        {
            _busPublisher = busPublisher;
        }

        public async Task CompensateAsync(OrderCanceled message, ISagaContext context)
        {
            await Task.CompletedTask;
        }

        public async Task CompensateAsync(CancelOrderRejected message, ISagaContext context)
        {
            await Task.CompletedTask;
        }

        public async Task CompensateAsync(ProductsReleased message, ISagaContext context)
        {
            await Task.CompletedTask;
        }

        public async Task CompensateAsync(ReleaseProductsRejected message, ISagaContext context)
        {
            await Task.CompletedTask;
        }

        public async Task HandleAsync(OrderCanceled message, ISagaContext context)
        {
            await _busPublisher.SendAsync(new ReleaseProducts(message.Id, message.Products),
                CorrelationContext.FromId(context.CorrelationId));
        }


        public async Task HandleAsync(CancelOrderRejected message, ISagaContext context)
        {
            Reject();
            await Task.CompletedTask;
        }

        public async Task HandleAsync(ProductsReleased message, ISagaContext context)
        {
            Complete();
            await Task.CompletedTask;
        }

        public async Task HandleAsync(ReleaseProductsRejected message, ISagaContext context)
        {
            Reject();
            await Task.CompletedTask;
        }
    }
}
