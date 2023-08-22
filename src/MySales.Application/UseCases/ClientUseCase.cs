using AutoMapper;
using MMySales.Model.Entities;
using MySales.Application.Contracts.Repositories;
using MySales.Application.Contracts.UseCases;
using MySales.Model.DTOs.Client;
using MySales.Model.Entities;

namespace MySales.Application.UseCases
{
    public class ClientUseCase : IClientUseCase
    {
        private readonly IRepository<Client> _clientRepository;
        private readonly IMapper _mapper;

        public ClientUseCase(IMapper mapper, IRepository<Client> clientRepository)
        {
            _mapper = mapper;
            _clientRepository = clientRepository;
        }

        public IEnumerable<Client> GetAll()
        {
            var clients = _clientRepository.GetAll();
            return clients.ToList();
        }

        public async Task<long> CreateAsync(CreateClientDto createClient)
        {
            var entity = _mapper.Map<Client>(createClient);
            _clientRepository.Add(entity);

            await _clientRepository.SaveChangesAsync();

            return entity.Id;
        }
    }
}
