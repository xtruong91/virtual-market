using VirtualMarket.Common.Messages;

namespace VirtualMarket.Services.Identity.Messages.Commands
{
    public class RefreshAccessToken : ICommand
    {
        public string Token { get; }
        public RefreshAccessToken(string token)
        {
            Token = token;
        }
    }
}
