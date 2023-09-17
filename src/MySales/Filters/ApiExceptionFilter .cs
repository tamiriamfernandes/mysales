using FluentValidation;
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
        var message = context.Exception.Message;
        if (context.Exception is ValidationException validationException)
        {
            message = string.Join(" ", validationException.Errors);
        }

        _logger.LogError(context.Exception, message);

        var apiResponse = new
        {
            Success = false,
            Message = message
        };

        context.Result = new ObjectResult(apiResponse)
        {
            StatusCode = 500 
        };
    }
}
