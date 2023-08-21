using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MySales.Api.Filters;

public class ApiExceptionFilter : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
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
