using FoodScrapper.Services.WebScrapper;
using Xunit;

namespace FoodScrapper.Tests.FoodScrapper.UnitTests
{
    public class WebScrapperUnitTests
    {
        [Fact]
        public void GivenAValidUrl_WebScrapper_ShouldHaveListOfProducts()
        {
            //arrange
            var url = "https://world.openfoodfacts.org/";

            //act
            var products = new WebScrapper(url);

            //assert
            Assert.True(products.Products.Count() > 0);
        }

        [Fact]
        public void GivenAEmptyUrl_WebScrapper_ShouldThrowException()
        {
            //arrange
            var url = "";

            //act-assert
            Assert.Throws<UriFormatException>(
               () => new WebScrapper(url));
        }

        [Fact]
        public void GivenAInvalidUrl_WebScrapper_ShouldThrowException()
        {
            //arrange
            var url = "https://www.google.com.br";

            //act-assert
            Assert.Throws<InvalidOperationException>(
               () => new WebScrapper(url));
        }
    }
}
