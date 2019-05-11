using System.Threading.Tasks;

namespace VirtualMarket.Common.Consul
{
    public interface IConsulHttpClient
    {
        Task<T> GetAsync<T>(string requestUri);
    }
}
