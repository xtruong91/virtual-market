using Newtonsoft.Json;
using System;
using VirtualMarket.Common.Messages;

namespace VirtualMarket.Services.Operations.Messages.Orders.Commands
{
    [MessageNamespace("orders")]
    public class ApproveOrder : ICommand
    {
        public Guid Id { get; }
        [JsonConstructor]
        public ApproveOrder(Guid id)
        {
            Id = id;
        }
    }
}
