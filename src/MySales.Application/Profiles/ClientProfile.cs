using AutoMapper;
using MySales.Model.Entities;
using MySales.Model.DTOs.Client;

namespace MySales.Application.Profiles;

public class ClientProfile : Profile
{
    public ClientProfile()
    {
        CreateMap<CreateClientDto, Client>();
    }
}
