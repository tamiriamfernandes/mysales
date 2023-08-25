using Microsoft.AspNetCore.Mvc;
using MySales.Application.Contracts.UseCases;
using MySales.Application.UseCases;
using MySales.Model.DTOs.Product;
using MySales.Model.DTOs.User;

namespace MySales.Api.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/users")]
public class OauthController : Controller
{
    private readonly IOauthUseCase _userUseCase;

    public OauthController(IOauthUseCase userUseCase)
    {
        _userUseCase = userUseCase;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUserDto createUser)
    {
        var result = await _userUseCase.CreateAsync(createUser);
        return Ok(result);
    }
}
