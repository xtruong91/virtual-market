using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using VirtualMarket.Common.Messages;

namespace VirtualMarket.Services.SignalR.Messages.Events
{
    [MessageNamespace("operations")]
    public class OperationPending : IEvent
    {
        public Guid Id { get; }
        public Guid UserId { get; }
        public string Name { get; }
        public string Resource { get; }
        [JsonConstructor]
        public OperationPending(Guid id, Guid userId,
            string name, string resource)
        {
            Id = id;
            UserId = userId;
            Name = name;
            Resource = resource;
        }
    }
}
