using Newtonsoft.Json;
using System;

namespace VirtualMarket.Services.Messages.Events.Identity
{
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
