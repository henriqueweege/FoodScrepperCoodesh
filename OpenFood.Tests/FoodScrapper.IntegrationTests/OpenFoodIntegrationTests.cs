
using FoodScrapper.WebApi.Services;
using MySqlX.XDevAPI.Common;
using FoodScrapper.Domain.Data.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FoodScrapper.Tests.FoodScrapper.IntegrationTests
{
    public class OpenFoodIntegrationTests
    {
        public HttpClient Client { get; set; }
        public OpenFoodIntegrationTests()
        {
            var app = new MyWebApplication();
            Client = app.CreateClient();
        }

        [Fact]
        public void GetMessage_ShouldReturnMessage()
        {
            //arrange
            //act
            var response = Client.GetAsync("https://localhost:7211/OpenFood/");
            response.Wait();
            var result = response.Result.Content.ReadAsStringAsync();

            //assert
            Assert.Equal(result.Result, "Fullstack Challenge 20201026");
        }

        [Fact]
        public void GivenInvalidCode_GetByCode_ShouldReturnBadRequest()
        {
            //arrange
            var code = "asd";
            //act
            var response = Client.GetAsync($"https://localhost:7211/OpenFood/products/code?code={code}");
            response.Wait();
            var result = response.Result.Content.ReadAsStringAsync();

            //assert
            Assert.Contains("There is no product", result.Result);
        }

        [Fact]
        public void GetAll_ShouldReturnAllIfAny()
        {
            //arrange
            //act
            var response = Client.GetAsync($"https://localhost:7211/OpenFood/products?page=1&pageSize=200");
            response.Wait();
            var result = response.Result.Content.ReadFromJsonAsync<List<ReadProductDto>>();

            //assert
            try
            {
                result.Wait();
                var obj = result.Result[0];
                Assert.Equal(obj.GetType(), new ReadProductDto().GetType());
            }
            catch ( Exception ex )
            {
                Assert.Contains("NoContent", response.Result.StatusCode.ToString());
            }
        }
    }
}
