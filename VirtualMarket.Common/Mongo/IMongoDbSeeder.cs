using System.Threading.Tasks;

namespace VirtualMarket.Common.Mongo
{
    public interface IMongoDbSeeder
    {
        Task SeedAsync();
    }
}
