using MimeKit;
using System.Threading.Tasks;

namespace VirtualMarket.Services.Notifications.Serviecs
{
    public interface IMessagesService
    {
        Task SendAsync(MimeMessage message);
    }
}
