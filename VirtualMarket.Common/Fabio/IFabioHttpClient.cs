using System.Threading.Tasks;

namespace VirtualMarket.Common.Fabio
{
    public interface IFabioHttpClient
    {
        Task<T> GetAsync<T>(string requestUri);
    }
}
