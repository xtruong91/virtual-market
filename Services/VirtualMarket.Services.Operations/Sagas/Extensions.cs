using Autofac;
using Chronicle;
using System;
using System.Linq;
using System.Reflection;
using VirtualMarket.Common.Messages;

namespace VirtualMarket.Services.Operations.Sagas
{
    internal static class Extensions
    {
        private static readonly Type[] SagaTypes = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t => t.IsAssignableTo<ISaga>())
            .ToArray();
        internal static bool BelongsToSaga<TMessage>(this TMessage _) where TMessage : IMessage
            => SagaTypes.Any(t => t.IsAssignableTo<ISagaAction<TMessage>>());
    }
}
