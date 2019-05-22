using System.Threading.Tasks;
using VirtualMarket.Common.Handlers;
using VirtualMarket.Common.MailKit;
using VirtualMarket.Common.RabbitMq;
using VirtualMarket.Services.Notifications.Builders;
using VirtualMarket.Services.Notifications.Messages.Events;
using VirtualMarket.Services.Notifications.Serviecs;
using VirtualMarket.Services.Notifications.Templates;

namespace VirtualMarket.Services.Notifications.Handlers
{
    public class OrderCreatedHandler : IEventHandler<OrderCreated>
    {
        private readonly MailKitOptions _options;
        private readonly ICustomersService _customersService;
        private readonly IMessagesService _messageService;

        public OrderCreatedHandler(MailKitOptions options,
            ICustomersService customersService,
            IMessagesService messageServices)
        {
            _options = options;
            _customersService = customersService;
            _messageService = messageServices;
        }


        public async Task HandleAsync(OrderCreated @event, ICorrelationContext context)
        {
            var orderId = @event.Id.ToString("N");
            var customer = await _customersService.GetAsync(@event.CustomerId);
            var message = MessageBuilder
                .Create()
                .WithReceiver(customer.Email)
                .WithSender(_options.Email)
                .WithSubject(MessageTemplates.OrderCreatedBody, customer.FirstName,
                    customer.LastName, orderId)
                .Build();
            await _messageService.SendAsync(message);   
        }
    }
}
