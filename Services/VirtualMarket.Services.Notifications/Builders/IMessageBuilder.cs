using MimeKit;

namespace VirtualMarket.Services.Notifications.Builders
{
    public interface IMessageBuilder
    {
        IMessageBuilder WithSender(string senderEMail);
        IMessageBuilder WithReceiver(string receiverEmail);
        IMessageBuilder WithSubject(string subject);
        IMessageBuilder WithSubject(string template, params object[] @params);
        IMessageBuilder WithBody(string body);
        IMessageBuilder WithBody(string template, params object[] @params);
        MimeMessage Build();
    }
}
