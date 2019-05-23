using Newtonsoft.Json;
using System;
using VirtualMarket.Common.Messages;

namespace VirtualMarket.Services.Operations.Messages.Operations.Events
{
    [MessageNamespace("operation")]
    public class OperationPending : IEvent
    {
        public Guid Id { get; }
        public Guid UserId { get; }
        public string Name { get; }
        public string Resource { get; }
        [JsonConstructor]
        public OperationPending(Guid id, Guid userId, string name, string resource)
        {
            Id = id;
            UserId = userId;
            Name = name;
            Resource = resource;
        }
    }
}
