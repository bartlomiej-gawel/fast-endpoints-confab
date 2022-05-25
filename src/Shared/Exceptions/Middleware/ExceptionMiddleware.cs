using System.Collections.Concurrent;
using System.Net;
using Confab.Shared.Exceptions.CustomExceptions;
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

    private static async Task HandleExceptionAsync(Exception exception, HttpContext context)
    {
        var exceptionResponse = exception switch
        {
            DomainException ex => new ExceptionResponse(new ErrorsResponse(new Error(GetErrorCode(ex), ex.Message)), HttpStatusCode.BadRequest),
            FeatureException ex => new ExceptionResponse(new ErrorsResponse(new Error(GetErrorCode(ex), ex.Message)), HttpStatusCode.BadRequest),
            PolicyException ex => new ExceptionResponse(new ErrorsResponse(new Error(GetErrorCode(ex), ex.Message)), HttpStatusCode.BadRequest),
            _ => new ExceptionResponse(new ErrorsResponse(new Error("Error", "There was an error.")), HttpStatusCode.InternalServerError)
        };
        
        context.Response.StatusCode = (int)(exceptionResponse?.StatusCode ?? HttpStatusCode.InternalServerError);

        var response = exceptionResponse?.Response;
        if (response is null)
        {
            return;
        }
        
        await context.Response.WriteAsJsonAsync(response);
    }

    private static readonly ConcurrentDictionary<Type, string> Codes = new();
    
    private static string GetErrorCode(object exception) => Codes.GetOrAdd(exception.GetType(), exception.GetType().Name);
    
    private record Error(string Type, string Message);
    
    private record ErrorsResponse(params Error[] Errors);
    
    private record ExceptionResponse(object Response, HttpStatusCode StatusCode);
}