using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MySales.Api.Filters;

public class ApiExceptionFilter : ExceptionFilterAttribute
{
    private readonly ILogger<ApiExceptionFilter> _logger;

    public ApiExceptionFilter(ILogger<ApiExceptionFilter> logger)
    {
        _logger = logger;
    }

    public override void OnException(ExceptionContext context)
    {
        _logger.LogError(context.Exception, "Erro não tratado na API");

        var apiResponse = new
        {
            Success = false,
            Message = "Ocorreu um erro interno no servidor."
        };

        context.Result = new ObjectResult(apiResponse)
        {
            StatusCode = 500 // Código de status de erro interno do servidor
        };
    }
}
