using System.Threading.Tasks;
using MimeKit;
using VirtualMarket.Common.MailKit;
using MailKit.Net.Smtp;

namespace VirtualMarket.Services.Notifications.Serviecs
{
    public class MessagesService : IMessagesService
    {
        private readonly MailKitOptions _options;
        public MessagesService(MailKitOptions options)
        {
            _options = options;
        }
        public async Task SendAsync(MimeMessage message)
        {
            using (var client = new SmtpClient())
            {
                client.Connect(_options.SmptHost, _options.Port, true);
                client.Authenticate(_options.Username, _options.Password);
                await client.SendAsync(message);
                client.Disconnect(true);
            }
        }
    }
}
