using Microsoft.AspNetCore.Http;

namespace Confab.Shared.Exceptions.Middleware;

internal class ExceptionMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception exception)
        {
            await HandleExceptionAsync(exception, context);
        }
    }

    private async Task HandleExceptionAsync(Exception exception, HttpContext context)
    {
        var errorResponse = new
        {
            code = exception.GetType().Name,
            message = exception.Message
        };

        context.Response.StatusCode = 400;
        
        await context.Response.WriteAsJsonAsync(errorResponse);
    }

    private record Error(string Code, string Reason);
    
    private record ErrorsResponse(params Error[] Errors);
    
    private record ExceptionResponse(object Response, HttpStatusCode StatusCode);
}