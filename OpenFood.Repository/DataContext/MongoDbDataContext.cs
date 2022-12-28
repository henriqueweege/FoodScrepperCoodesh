using FoodScrapper.Domain.Data.Model;
using FoodScrapper.Infrastructure.JsonHandler;
using FoodScrapper.Repository.DataContext.Contract;
using MongoDB.Driver;

namespace FoodScrapper.Repository.DataContext
{
    public class MongoDbDataContext : IDataContext
    {
        public IMongoCollection<ProductModel> Context { get; private set; }
        public MongoDbDataContext()
        {
            var client = new MongoClient(JsonHandler.MongoDbStringConnection);
            var dataBase = client.GetDatabase(JsonHandler.MongoDbDataBaseName);

            Context = dataBase.GetCollection<ProductModel>("productModel");
        }
    }
}
