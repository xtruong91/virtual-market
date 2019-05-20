using System;
using VirtualMarket.Common.Messages;
using VirtualMarket.Common.Types;

namespace VirtualMarket.Common.RabbitMq
{
    public interface IBusSubscriber
    {
        IBusSubscriber SubscriberCommand<TCommand>(string @namespace = null, string queueName = null,
            Func<TCommand, VirtualMarketException, IRejectedEvent> onError = null)
            where TCommand : ICommand;
        IBusSubscriber SubscribeEvent<TEvent>(string @namespace = null, string queueName = null,
            Func<TEvent, VirtualMarketException, IRejectedEvent> onError = null)
            where TEvent : IEvent;
        object SubscribeCommand<T>(Func<object, object, CreateCustomerRejected> onError);
    }
}
