using AutoMapper;
using MySales.Application.Contracts.Repositories;
using MySales.Application.Contracts.UseCases;
using MySales.Model.DTOs.Client;
using MySales.Model.Entities;

namespace MySales.Application.UseCases;

public class CustomerCrudUseCase : ICustomerCrudUseCase
{
    private readonly IRepository<Customer> _customerRepository;
    private readonly IMapper _mapper;

    public CustomerCrudUseCase(IMapper mapper, IRepository<Customer> customerRepository)
    {
        _mapper = mapper;
        _customerRepository = customerRepository;
    }

    public IEnumerable<Customer> GetAll()
    {
        var clients = _customerRepository.GetAll();
        return clients.ToList();
    }

    public async Task<long> CreateAsync(CreateCustomerDto createCustomer)
    {
        var entity = _mapper.Map<Customer>(createCustomer);
        _customerRepository.Add(entity);

        await _customerRepository.SaveChangesAsync();

        return entity.Id;
    }
}
