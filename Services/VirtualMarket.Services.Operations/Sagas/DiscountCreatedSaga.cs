using Chronicle;
using System.Threading.Tasks;
using VirtualMarket.Common.RabbitMq;
using VirtualMarket.Services.Operations.Messages.Discounts.Events;
using VirtualMarket.Services.Operations.Messages.Notifications.Commands;

namespace VirtualMarket.Services.Operations.Sagas
{
    public class DiscountCreatedSaga : Saga,
          ISagaStartAction<DiscountCreated>
    {
        private readonly IBusPublisher _busPublisher;
        public DiscountCreatedSaga(IBusPublisher busPublisher)
        {
            _busPublisher = busPublisher;
        }
        public Task CompensateAsync(DiscountCreated message, ISagaContext context)
        {
            return _busPublisher.SendAsync(new SendEmailNotification("user1@virtualmarket.com", "Discount", $"New Discount:{message.Code}"),
                CorrelationContext.Empty);
        }

        public async Task HandleAsync(DiscountCreated message, ISagaContext context)
        {
            await Task.CompletedTask;
        }
    }
    public class State
    {
        public string Code { get; set; }
    }
}
