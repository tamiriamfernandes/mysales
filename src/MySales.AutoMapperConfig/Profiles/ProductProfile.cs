using AutoMapper;
using MySales.Application.DTOs.Product;
using MySales.Core.Entities;

namespace MySales.AutoMapperConfig.Profiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, CreateProductDto>().ReverseMap();    
    }
}