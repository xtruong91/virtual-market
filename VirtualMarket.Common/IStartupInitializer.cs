using System.Threading.Tasks;

namespace VirtualMarket.Common
{
    public interface IStartupInitializer
    {
        Task InitializeAsync();
        void AddInitializer(IInitializer initializer);
    }
}
