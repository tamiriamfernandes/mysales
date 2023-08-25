using AutoMapper;
using MySales.Model.DTOs.User;
using MySales.Model.Entities;

namespace MySales.Application.Profiles;

public class OauthProfile : Profile
{
    public OauthProfile()
    {
        CreateMap<CreateUserDto, User>();
    }
}
