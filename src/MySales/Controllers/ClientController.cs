using Microsoft.AspNetCore.Mvc;
using MySales.Api.Filters;
using MySales.Application.Contracts.UseCases;
using MySales.Model.DTOs.Client;

namespace MySales.Api.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/clients")]
[ApiResponseFilter]
public class ClientController : Controller
{
    private readonly IClientUseCase _clientUseCase;

    public ClientController(IClientUseCase clientUseCase)
    {
        _clientUseCase = clientUseCase;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var result = _clientUseCase.GetAll();

        if (!result.Any()) return NotFound();

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateClientDto createClient)
    {
        var result = await _clientUseCase.CreateAsync(createClient);
        return Ok(result);
    }
}
