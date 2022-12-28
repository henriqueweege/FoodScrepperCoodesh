using FoodScrapper.Domain.Data.Model;
using FoodScrapper.Infrastructure.JsonHandler;
using FoodScrapper.Repository.DataContext.Contract;
using Microsoft.EntityFrameworkCore;

namespace FoodScrapper.Repository.DataContext
{
    public class MySqlDataContext : DbContext, IDataContext
    {
        public DbSet<ProductModel> Product { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = JsonHandler.MySqlConnectionString;
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
    }
}
