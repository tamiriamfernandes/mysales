using AutoMapper;
using MySales.Application.Contracts;
using MySales.Model.DTOs.Product;
using MySales.Model.Entities;

namespace MySales.Application.UseCases
{
    public class ProductUseCase : IProductUseCase
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IMapper _mapper;

        public ProductUseCase(IMapper mapper, IRepository<Product> productRepository)
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
}
