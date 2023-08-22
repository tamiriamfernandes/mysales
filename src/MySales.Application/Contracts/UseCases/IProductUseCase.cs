using MySales.Model.DTOs.Product;
using MySales.Model.Entities;

namespace MySales.Application.Contracts.UseCases;

public interface IProductUseCase
{
    IEnumerable<DetailProductDto> GetAll();
    Task<long> CreateAsync(CreateProductDto createProduct);
}
