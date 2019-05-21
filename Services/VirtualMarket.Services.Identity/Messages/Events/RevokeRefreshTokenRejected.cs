using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using VirtualMarket.Common.Messages;

namespace VirtualMarket.Services.Identity.Messages.Events
{
  public class RevokeRefreshTokenRejected : IRejectedEvent
  {
        public Guid UserId { get; }
        public string Reason { get; }
        public string Code { get; }
        [JsonConstructor]
        public RevokeRefreshTokenRejected(Guid userId, string reason, string code)
        {
            UserId = userId;
            Reason = reason;
            Code = code;
        }
  }
}
