using Newtonsoft.Json;
using System;
using VirtualMarket.Common.Messages;

namespace VirtualMarket.Services.Operations.Messages.Identity.Events
{
    [MessageNamespace("identity")]
    public class SignedIn : IEvent
    {
        public Guid UserId { get; }
        [JsonConstructor]
        public SignedIn(Guid userId)
        {
            UserId = userId;
        }
    }
}
