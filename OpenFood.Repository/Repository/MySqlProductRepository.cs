using FoodScrapper.Domain.Data;
using FoodScrapper.Repository.DataContext;
using FoodScrapper.Repository.DataContext.Contract;
using FoodScrapper.Repository.Repository.Contract;
using FoodScrapper.Domain.Data.Model;

namespace FoodScrapper.Repository.Repository
{
    public class MySqlProductRepository : IRepository<ProductModel>
    {
        public MySqlDataContext Context { get; set; }
        public MySqlProductRepository(IDataContext context)
        {
            Context = (MySqlDataContext)context;
        }
        public List<ProductModel> GetAll()
        {
            try
            {
                return Context.Product.ToList();
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
                var product = Context.Product.FirstOrDefault(p => p.Code == code);
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
                Context.Add(objToSave);
                if (Context.SaveChanges() > 0)
                {
                    objToSave.Status = (int)StatusEnum.Imported;
                    Context.Update(objToSave);
                    if (Context.SaveChanges() > 0)
                    {
                        return objToSave;
                    }
                    throw new Exception($"Error trying to save object with code {objToSave.Code}. Please, try again later.");
                };
                throw new Exception($"Error trying to save object with code {objToSave.Code}. Please, try again later.");
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
