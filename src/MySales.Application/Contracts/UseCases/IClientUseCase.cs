using MMySales.Model.Entities;
using MySales.Model.DTOs.Client;

namespace MySales.Application.Contracts.UseCases;

public interface IClientUseCase
{
    IEnumerable<Client> GetAll();
    Task<long> CreateAsync(CreateClientDto createClient);
}
