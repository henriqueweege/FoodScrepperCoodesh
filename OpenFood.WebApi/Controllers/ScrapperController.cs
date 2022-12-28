using AutoMapper;
using FoodScrapper.Domain.Data.Dtos;
using FoodScrapper.Domain.Data.Model;
using FoodScrapper.Repository.Repository.Contract;
using FoodScrapper.Services.WebScrapper;
using Microsoft.AspNetCore.Mvc;

namespace FoodScrapper.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScrapperController : ControllerBase
    {
        private IRepository<ProductModel> ProductRepository { get; set; }
        private IMapper Mapper { get; set; }
        public ScrapperController(IRepository<ProductModel> productRepository, IMapper mapper)
        {
            ProductRepository = productRepository;
            Mapper = mapper;
        }


        /// <summary>
        ///Starts the scrapping processes.
        /// </summary>
        /// <returns>
        /// 200 - success;
        /// 404 - bad request;
        /// 500 - server error;
        /// </returns>
        [HttpPost]
        public IActionResult ScrapOpenFood()
        {
            var scrapper = new WebScrapper("https://world.openfoodfacts.org/");


            var productsCreated = new List<ReadProductDto>();

            foreach (var item in scrapper.Products)
            {
                try
                {
                    var productCreated = ProductRepository.Save(Mapper.Map<ProductModel>(item));
                    productsCreated.Add(Mapper.Map(productCreated, new ReadProductDto()));
                }
                catch (Exception)
                {

                    throw;
                }
            }
            if (productsCreated.Count > 0) return Ok(productsCreated);
            return BadRequest();
        }
    }
}