using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;
using VirtualMarket.Services.SignalR.Framework;
using VirtualMarket.Services.SignalR.Hubs;

namespace VirtualMarket.Services.SignalR.Services
{
    public class HubWrapper : IHubWrapper
    {
        private readonly IHubContext<VirtualMarketHub> _hubContext;

        public HubWrapper(IHubContext<VirtualMarketHub> hubContext)
        {
            _hubContext = hubContext;
        }
        public async Task PublishToAllAsync(string message, object data)
            => await _hubContext.Clients.All.SendAsync(message, data);

        public async Task PublishToUserAsync(Guid userId, string message, object data)
            => await _hubContext.Clients.Group(userId.ToUserGroup()).SendAsync(message, data);
    }
}
