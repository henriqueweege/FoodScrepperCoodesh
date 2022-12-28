using FluentScheduler;
using FoodScrapper.WebApi.Services;
using Microsoft.Graph;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodScrapper.Infrastructure.TaskHandler
{
    public class ScrapperTriggerer : IJob
    {
        public void Execute()
        {
            var webApp = new MyWebApplication();
            var client = webApp.CreateClient();
            var stringContent = new StringContent(JsonConvert.SerializeObject(""), Encoding.UTF8, "");
            var response = client.PostAsync("https://localhost:7211/Scrapper", stringContent);
            response.Wait();
        }
    }
}
