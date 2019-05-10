using System.Collections.Generic;

namespace VirtualMarket.Common.Authentication
{
    public class JsonWebTokenPayload
    {
        public string Subject { get; set; }
        public string Role { get; set; }
        public string Expires { get; set; }
        public IDictionary<string, string> Claims { get; set; }
    }
}
