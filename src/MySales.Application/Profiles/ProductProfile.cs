using AutoMapper;
using MySales.Model.DTOs.Product;
using MySales.Model.Entities;

namespace MySales.Application.Profiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<CreateProductDto, Product>();    
    }
}