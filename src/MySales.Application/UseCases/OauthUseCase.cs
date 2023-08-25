using AutoMapper;
using MySales.Application.Contracts.Repositories;
using MySales.Application.Contracts.UseCases;
using MySales.Core.Contracts;
using MySales.Model.DTOs.User;
using MySales.Model.Entities;

namespace MySales.Application.UseCases;

public class OauthUseCase : IOauthUseCase
{
    private readonly IRepository<User> _userRepository;
    private readonly IOauthCore _userCore;
    private readonly IMapper _mapper;

    public OauthUseCase(IMapper mapper, IRepository<User> userRepository, IOauthCore userCore)
    {
        _mapper = mapper;
        _userRepository = userRepository;
        _userCore = userCore;
    }

    public async Task<long> CreateAsync(CreateUserDto createUser)
    {
        var passwordEncrypt = _userCore.Encrypt(createUser.password);

        createUser = createUser with { password = passwordEncrypt };

        var entity = _mapper.Map<User>(createUser);
        _userRepository.Add(entity);

        await _userRepository.SaveChangesAsync();

        return entity.Id;
    }
}
