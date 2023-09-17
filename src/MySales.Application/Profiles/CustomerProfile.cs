using AutoMapper;
using MySales.Model.Entities;
using MySales.Model.DTOs.Client;

namespace MySales.Application.Profiles;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<InputCustomerDto, Customer>();
    }
}
