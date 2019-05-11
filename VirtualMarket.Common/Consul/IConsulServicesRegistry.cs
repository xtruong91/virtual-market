using Consul;
using System.Threading.Tasks;

namespace VirtualMarket.Common.Consul
{
    public interface IConsulServicesRegistry
    {
        Task<AgentService> GetAsync(string name);
    }
}
