using AutoMapper;
using MySales.Model.DTOs.Product;
using MySales.Model.Entities;

namespace MySales.Application.Profiles.Product;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<CreateProductDto, Product>();
    }
}