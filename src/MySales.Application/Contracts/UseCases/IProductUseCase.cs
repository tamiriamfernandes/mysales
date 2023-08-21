using MySales.Model.DTOs.Product;

namespace MySales.Application.Contracts.UseCases;

public interface IProductUseCase
{
    Task<long> CreateProductAsync(CreateProductDto createProduct);
}
