using AutoMapper;
using MySales.Model.DTOs.Product;
using MySales.Model.DTOs.Sale;
using MySales.Model.Entities;

namespace MySales.Application.Profiles;

public class SaleProfile : Profile
{
    public SaleProfile()
    {
        CreateMap<InputSaleDto, Sale>();
    }
}
