using MySales.Model.Entities;
using MySales.Model.DTOs.Client;

namespace MySales.Application.Contracts.UseCases;

public interface ICustomerCrudUseCase
{
    IEnumerable<Customer> GetAll();
    Task<long> CreateAsync(CreateCustomerDto createClient);
}
