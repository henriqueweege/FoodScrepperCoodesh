using AutoMapper;
using FoodScrapper.Domain.Data.Dtos;
using FoodScrapper.Domain.Data.Model;

namespace FoodScrapper.Domain.Data.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductDto, ProductModel>();
            CreateMap<ProductModel,ReadProductDto>();
            CreateMap<ReadProductDto, ProductModel>();
        }
    }
}
