using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using VirtualMarket.Common.Handlers;
using VirtualMarket.Common.RabbitMq;
using VirtualMarket.Services.Notifications.Messages.Commands;

namespace VirtualMarket.Services.Notifications.Handlers
{
    public class SendEmailNotificationHandler : ICommandHandler<SendEmailNotification>
    {
        private readonly ILogger<SendEmailNotificationHandler> _logger;

        public SendEmailNotificationHandler(ILogger<SendEmailNotificationHandler> logger)
        {
            _logger = logger;
        }

        public Task HandleAsync(SendEmailNotification command, ICorrelationContext context)
        {
            _logger.LogInformation($"Sending an email message to: '{command.Email}'.");
            return Task.CompletedTask;
        }
    }
}
