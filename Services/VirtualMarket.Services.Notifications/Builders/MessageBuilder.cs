using MimeKit;

namespace VirtualMarket.Services.Notifications.Builders
{
    public class MessageBuilder : IMessageBuilder
    {
        private readonly MimeMessage _message;
        private MessageBuilder()
        {
            _message = new MimeMessage();
        }

        public static IMessageBuilder Create()
            => new MessageBuilder();
        public MimeMessage Build()
         => _message;

        public IMessageBuilder WithBody(string body)
        { 
            _message.Body = new TextPart("plain")
               {
                   Text = body
               };
            return this;
        }


        public IMessageBuilder WithBody(string template, params object[] @params)
         => this.WithSubject(string.Format(template, @params));

        public IMessageBuilder WithReceiver(string receiverEmail)
        {
            _message.To.Add(new MailboxAddress(receiverEmail));
            return this;
        }

        public IMessageBuilder WithSender(string senderEmail)
        {
            _message.From.Add(new MailboxAddress(senderEmail));
            return this;
        }

        public IMessageBuilder WithSubject(string subject)
        {
            _message.Subject = subject;
            return this;
        }

        public IMessageBuilder WithSubject(string template, params object[] @params)
            => this.WithSubject(string.Format(template, @params));
    }
}
