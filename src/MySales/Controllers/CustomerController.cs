using Microsoft.AspNetCore.Mvc;
using MySales.Api.Filters;
using MySales.Application.Contracts.UseCases;
using MySales.Model.DTOs.Client;

namespace MySales.Api.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/customers")]
[ApiResponseFilter]
public class CustomerController : Controller
{
    private readonly ICustomerCrudUseCase _customerUseCase;

    public CustomerController(ICustomerCrudUseCase customerUseCase)
    {
        _customerUseCase = customerUseCase;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var result = _customerUseCase.GetAll();

        if (!result.Any()) return NotFound();

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCustomerDto createCustomer)
    {
        var result = await _customerUseCase.CreateAsync(createCustomer);
        return Ok(result);
    }
}
