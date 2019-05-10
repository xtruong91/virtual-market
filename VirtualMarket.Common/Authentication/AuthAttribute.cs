using Microsoft.AspNetCore.Authorization;

namespace VirtualMarket.Common.Authentication
{
    public class AuthAttribute : AuthorizeAttribute
    {
        public AuthAttribute(string scheme, string policy = "")
            : base(policy)
        {
            AuthenticationSchemes = scheme;
        }
    }
}
