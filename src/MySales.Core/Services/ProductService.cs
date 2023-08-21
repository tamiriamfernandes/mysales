using AutoMapper;
using MySales.Application.Contracts;
using MySales.Application.DTOs.Product;
using MySales.Core.Entities;
using MySales.Core.Repositories;

namespace MySales.Core.Services;

public class ProductService : IProductService
{
    private readonly IRepository<Product> _productRepository;
    private readonly IMapper _mapper;

    public ProductService(IMapper mapper, IRepository<Product> productRepository)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }

    public async Task<long> CreateProductAsync(CreateProductDto createProduct)
    {
        var entity = _mapper.Map<Product>(createProduct);
        _productRepository.Add(entity);
        
        await _productRepository.SaveChangesAsync();

        return entity.Id;
    }
}
