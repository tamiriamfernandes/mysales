using MySales.Model.DTOs.User;

namespace MySales.Application.Contracts.UseCases;

public interface IOauthUseCase
{
    Task<long> CreateAsync(CreateUserDto createUser);
}
