using Microsoft.AspNetCore.Mvc.Testing;

namespace FoodScrapper.WebApi.Services
{
    class MyWebApplication : WebApplicationFactory<Program>
    {
        protected override IHost CreateHost(IHostBuilder builder)
        {
            return base.CreateHost(builder);
        }
    }
}
