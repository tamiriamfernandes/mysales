using AutoMapper;
using MySales.Model.DTOs.Product;
using MySales.Model.Entities;

namespace MySales.AutoMapperConfig.Profiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<CreateProductDto, Product>();    
    }
}