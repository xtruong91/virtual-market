using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;
using VirtualMarket.Common.Authentication;
using VirtualMarket.Services.SignalR.Framework;

namespace VirtualMarket.Services.SignalR.Hubs
{
    public class VirtualMarketHub : Hub
    {
        private readonly IJwtHandler _jwtHandler;
        public VirtualMarketHub(IJwtHandler jwtHandler)
        {
            _jwtHandler = jwtHandler;
        }
        public async Task InitializeAsync(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                await DisconnectAsync();
            }
            try
            {
                var payload = _jwtHandler.GetTokenPayload(token);
                if (payload == null)
                {
                    await DisconnectAsync();
                    return;
                }
                var group = Guid.Parse(payload.Subject).ToUserGroup();
                await Groups.AddToGroupAsync(Context.ConnectionId, group);
                await ConnectAsync();
            }
            catch
            {
                await DisconnectAsync();
            }
        }

        private async Task ConnectAsync()
        {
            await Clients.Client(Context.ConnectionId).SendAsync("connected");
        }

        private async Task DisconnectAsync()
        {
            await Clients.Client(Context.ConnectionId).SendAsync("disconnected");
        }
    }
}
