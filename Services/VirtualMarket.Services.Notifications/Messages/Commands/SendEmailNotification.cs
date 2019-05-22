using Newtonsoft.Json;
using VirtualMarket.Common.Messages;

namespace VirtualMarket.Services.Notifications.Messages.Commands
{
    public class SendEmailNotification : ICommand
    {
        public string Email { get; }
        public string Title { get; }
        public string Message { get; }

        [JsonConstructor]
        public SendEmailNotification(string email, string title, string message)
        {
            Email = email;
            Title = title;
            Message = message;
        }
    }
}
