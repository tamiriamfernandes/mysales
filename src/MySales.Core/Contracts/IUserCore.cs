using MySales.Model.DTOs.User;

namespace MySales.Core.Contracts;

public interface IUserCore
{
    Task CreateUserAsync(CreateUserDto createUser);
}
