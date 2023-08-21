using MySales.Application.DTOs.Product;

namespace MySales.Application.Contracts;

public interface IProductService
{
    Task<long> CreateProductAsync(CreateProductDto createProduct);
}
