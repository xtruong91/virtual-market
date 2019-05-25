using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualMarket.Services.Messages.Events
{
    public class Resource
    {
        public string Service { get; }
        public string Endpoint { get; }
        protected Resource(string service, string endpoint)
        {
            Service = service.ToLowerInvariant();
            Endpoint = service.ToLowerInvariant();
        }
        public static Resource Create(string service, string endpoint)
            => new Resource(service, endpoint);
    }
}
