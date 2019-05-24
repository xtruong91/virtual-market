using Newtonsoft.Json;
using System;
using VirtualMarket.Common.Messages;

namespace VirtualMarket.Services.Orders.Messages.Commands
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
