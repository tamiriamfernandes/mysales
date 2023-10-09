using Microsoft.AspNetCore.Mvc;
using MySales.Api.Filters;
using MySales.Application.Contracts.UseCases;
using MySales.Model.DTOs.Client;
using MySales.Model.DTOs.Sale;
using MySales.Model.Entities;

namespace MySales.Api.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/sales")]
[ApiResponseFilter]
public class SaleController : Controller
{
    private readonly ISaleUseCase _saleUseCase;

    public SaleController(ISaleUseCase saleUseCase)
    {
        _saleUseCase = saleUseCase;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] InputSaleDto sale)
    {
        var result = await _saleUseCase.CreateAsync(sale);
        return Ok(result);
    }
}
