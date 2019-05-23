using Newtonsoft.Json;
using System;
using VirtualMarket.Common.Messages;

namespace VirtualMarket.Services.Operations.Messages.Operations.Events
{
    [MessageNamespace("operation")]
    public class OperationCompleted : IEvent
    {
        public Guid Id { get; }
        public Guid UserId { get; }
        public string Name { get; }
        public string Resource { get; }
        [JsonConstructor]
        public OperationCompleted(Guid id, Guid userId, string name, string resource)
        {
            Id = id;
            UserId = userId;
            Name = name;
            Resource = resource;
        }
    }
}
