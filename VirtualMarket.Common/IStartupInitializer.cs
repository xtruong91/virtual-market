namespace VirtualMarket.Common
{
    public interface IStartupInitializer
    {
        void AddInitializer(IInitializer initializer);
    }
}
