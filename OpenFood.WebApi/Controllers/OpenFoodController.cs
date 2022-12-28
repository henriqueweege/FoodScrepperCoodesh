using AutoMapper;
using FoodScrapper.Domain.Data.Dtos;
using FoodScrapper.Domain.Data.Model;
using FoodScrapper.Infrastructure.JsonHandler;
using FoodScrapper.Repository.Repository.Contract;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace FoodScrapper.WebApi.Controllers
{
    [ApiController]
    public class OpenFoodController : ControllerBase
    {
        private IRepository<ProductModel> ProductRepository { get; set; }
        private IMapper Mapper { get; set; }
        public OpenFoodController(IRepository<ProductModel> productRepository, IMapper mapper)
        {
            ProductRepository = productRepository;
            Mapper = mapper;
        }

        /// <summary>
        ///Get message.
        /// </summary>
        /// <returns>
        /// </returns>
        [HttpGet, Route("OpenFood/")]
        public IActionResult GetMessage()
        {
            try
            {
                return Ok(JsonHandler.Message);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        ///Get product by code.
        /// </summary>
        /// <returns>
        /// /// </returns>
        [HttpGet, Route("OpenFood/products/code")]
        public ActionResult<ReadProductDto> GetByCode([FromQuery] string code)
        {
            try
            {
                var product = ProductRepository.GetByCode(code);

                if (product != null)
                {
                    return Ok(Mapper.Map(product, new ReadProductDto()));
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("There is no product"))
                {
                    return BadRequest(ex.Message);
                }
                throw;
            }
        }


        /// <summary>
        ///Get all products.
        /// </summary>
        /// <returns>
        /// </returns>
        [HttpGet, Route("OpenFood/products")]
        public ActionResult<List<ReadProductDto>> GetAll(int page, int pageSize)
        {
            try
            {
                var products = ProductRepository.GetAll();
                if (products.Count>0)
                {
                    var productsPaging = products.Skip((page - 1) * pageSize).Take(pageSize);
                    var productsToReturn = new List<ReadProductDto>();

                    foreach (var product in productsPaging)
                    {
                        try
                        {
                            productsToReturn.Add(Mapper.Map(product, new ReadProductDto()));
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                    }
                    if (productsToReturn.Count > 0) return Ok(productsToReturn);
                    return NoContent();
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
