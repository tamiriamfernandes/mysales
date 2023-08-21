﻿using Microsoft.AspNetCore.Mvc;
using MySales.Application.Contracts;
using MySales.Application.DTOs.Product;
using MySales.Core.Services;

namespace MySales.Api.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/products")]
public class ProductController : Controller
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductDto createProduct)
    {
        var result = await _productService.CreateProductAsync(createProduct);
        return Ok(result);
    }
}
