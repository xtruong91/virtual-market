using Newtonsoft.Json;
using System;
using VirtualMarket.Common.Messages;

namespace VirtualMarket.Services.Identity.Messages.Commands
{
    public class SignUp : ICommand
    {
        public Guid Id { get; }
        public string Email { get; }
        public string Password { get; }
        public string Role { get; }
        [JsonConstructor]
        public SignUp(Guid id, string email, string password, string role)
        {
            Id = id;
            Email = email;
            Password = password;
            Role = role;
        }
    }
}
