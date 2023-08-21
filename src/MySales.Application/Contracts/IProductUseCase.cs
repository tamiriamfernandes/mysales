
using MySales.Model.DTOs.Product;

namespace MySales.Application.Contracts;

public interface IProductUseCase
{
    Task<long> CreateProductAsync(CreateProductDto createProduct);
}
