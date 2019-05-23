using Newtonsoft.Json;
using System;
using VirtualMarket.Common.Messages;

namespace VirtualMarket.Services.Operations.Messages.Orders.Events
{

    [MessageNamespace("orders")]
    public class ApproveOrderRejected : IRejectedEvent
    {
        public Guid Id { get; }
        public string Reason { get; }
        public string Code { get; }
        [JsonConstructor]
        public ApproveOrderRejected(Guid id, string reason, string code)
        {
            Id = id;
            Reason = reason;
            Code = code;
        }
    }
}
