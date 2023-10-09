using MySales.Model.DTOs.Sale;

namespace MySales.Application.Contracts.UseCases;

public interface ISaleUseCase
{
    Task<long> CreateAsync(InputSaleDto sale);
}
