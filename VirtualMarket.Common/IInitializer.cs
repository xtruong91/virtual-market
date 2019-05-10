using System.Threading.Tasks;

namespace VirtualMarket.Common
{
    public interface IInitializer
    {
        Task InitializeAsync();
    }
}
