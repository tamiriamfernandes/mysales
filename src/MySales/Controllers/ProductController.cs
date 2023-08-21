using Microsoft.AspNetCore.Mvc;
using MySales.Api.Filters;
using MySales.Application.Contracts.UseCases;
using MySales.Model.DTOs.Product;

namespace MySales.Api.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/products")]
[ApiResponseFilter]
public class ProductController : Controller
{
    private readonly IProductUseCase _productUseCase;

    public ProductController(IProductUseCase productUseCase)
    {
        _productUseCase = productUseCase;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductDto createProduct)
    {
        var result = await _productUseCase.CreateProductAsync(createProduct);
        return Ok(result);
    }
}
