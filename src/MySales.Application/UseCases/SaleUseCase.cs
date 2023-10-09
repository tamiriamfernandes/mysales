using AutoMapper;
using MySales.Application.Contracts.Repositories;
using MySales.Application.Contracts.UseCases;
using MySales.Core.Contracts;
using MySales.Model.DTOs.Sale;
using MySales.Model.Entities;

namespace MySales.Application.UseCases;

public class SaleUseCase : ISaleUseCase
{
    private readonly IAccountReceiveCore _accountReceiveCore;
    private readonly IRepository<Sale> _saleRepository;
    private readonly IRepository<AccountReceive> _accountReceiveRepository;
    private readonly IMapper _mapper;

    public SaleUseCase(IMapper mapper, IAccountReceiveCore accountReceiveCore, IRepository<Sale> saleRepository, IRepository<AccountReceive> accountReceiveRepository)
    {
        _mapper = mapper;
        _saleRepository = saleRepository;
        _accountReceiveCore = accountReceiveCore;
        _accountReceiveRepository = accountReceiveRepository;
    }

    public async Task<long> CreateAsync(InputSaleDto inputSale)
    {
        var entity = _mapper.Map<Sale>(inputSale);
        _saleRepository.Add(entity);

        await _saleRepository.SaveChangesAsync();

        var receives = _accountReceiveCore.GenerateParcels(inputSale.Total, inputSale.Installments, inputSale.DatePay);
        receives.ForEach(receive => { receive.SaleId = entity.Id; receive.CustomerId = inputSale.CustomerId; });

        _accountReceiveRepository.AddRange(receives);
        await _accountReceiveRepository.SaveChangesAsync();

        return entity.Id;
    }
}
