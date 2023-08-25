using Microsoft.AspNetCore.Mvc;
using MySales.Api.Filters;
using MySales.Application.Contracts.UseCases;
using MySales.Model.DTOs.Oauth;
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

    [HttpGet]
    public IActionResult GetAll()
    {
        var result = _productUseCase.GetAll();

        if (!result.Any()) return NotFound();

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductDto createProduct)
    {
        var result = await _productUseCase.CreateAsync(createProduct);
        return Ok(result);
    }
}
