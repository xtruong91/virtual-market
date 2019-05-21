using Newtonsoft.Json;
using VirtualMarket.Common.Messages;

namespace VirtualMarket.Services.Identity.Messages.Commands
{
    public class SignIn : ICommand
    {
        public string Email { get; }
        public string Password { get; }
        [JsonConstructor]
        public SignIn(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
