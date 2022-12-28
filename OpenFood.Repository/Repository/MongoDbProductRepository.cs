using FoodScrapper.Domain.Data;
using FoodScrapper.Domain.Data.Model;
using FoodScrapper.Repository.DataContext;
using FoodScrapper.Repository.DataContext.Contract;
using FoodScrapper.Repository.Repository.Contract;
using MongoDB.Driver;

namespace FoodScrapper.Repository.Repository
{
    public class MongoDbProductRepository : IRepository<ProductModel>
    {
        private IMongoCollection<ProductModel> Context { get; set; }
        public MongoDbProductRepository(IDataContext mongoDbDataContext)
        {
            var mongoContext = (MongoDbDataContext)mongoDbDataContext;
            Context = mongoContext.Context;
        }
        public List<ProductModel> GetAll()
        {
            try
            {
                return Context.Find(p => true).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ProductModel GetByCode(string code)
        {
            try
            {
                var product = Context.Find(p => p.Code == code).FirstOrDefault();
                if (product != null)
                {
                    return product;
                }
                throw new ArgumentException($"There is no product with the code {code}");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ProductModel Save(ProductModel objToSave)
        {
            try
            {
                objToSave.Id = Guid.NewGuid().ToString();
                objToSave.Imported = DateTime.Now;
                objToSave.Status = (int)StatusEnum.Imported;
                Context.InsertOne(objToSave);

                return (objToSave);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
