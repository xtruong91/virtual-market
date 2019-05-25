using System.Threading.Tasks;

namespace VirtualMarket.Services.Storage.Services
{
    public interface ICache
    {
        Task<T> GetAsync<T>(string key);
        Task SetAsync<T>(string key, T value);
    }
}
