using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using VirtualMarket.Common.Messages;
using VirtualMarket.Common.RabbitMq;
using VirtualMarket.Services.Operations.Messages.Operations.Events;

namespace VirtualMarket.Services.Operations
{
    public static class Subscriptions
    {
        private static readonly Assembly MessageAssembly = typeof(Subscriptions).Assembly;
        private static readonly ISet<Type> ExcludeMessages = new HashSet<Type>(new[]
        {
            typeof(OperationPending),
            typeof(OperationCompleted),
            typeof(OperationRejected)
        });

        public static IBusSubscriber SubscribeAllMessages(this IBusSubscriber subscriber)
            => subscriber.SubscribeAllCommands().SubscribeAllEvents();
        private static IBusSubscriber SubscribeAllCommands(this IBusSubscriber subscriber)
            => subscriber.SubscribeAllMessages<ICommand>(nameof(IBusSubscriber.SubscribeCommand));
        private static IBusSubscriber SubscribeAllEvents(this IBusSubscriber subscriber)
            => subscriber.SubscribeAllMessages<IEvent>(nameof(IBusSubscriber.SubscribeEvent));

        private static IBusSubscriber SubscribeAllMessages<TMessage>(this IBusSubscriber subscriber, string subscriberMethod)
        {
            var messageTypes = MessageAssembly
                .GetTypes()
                .Where(t => t.IsClass && typeof(TMessage).IsAssignableFrom(t))
                .Where(t => !ExcludeMessages.Contains(t))
                .ToList();
            messageTypes.ForEach(mt => subscriber.GetType()
            .GetMethod(subscriberMethod)
            .MakeGenericMethod(mt)
            .Invoke(subscriber,
            new object[] { mt.GetCustomAttribute<MessageNamespaceAttribute>()?.Namespace, null, null }));
            return subscriber;
        }
    }
}
