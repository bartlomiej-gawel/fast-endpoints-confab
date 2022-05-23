using System.Net;
using Confab.Shared.Exceptions.CustomExceptions;

namespace Confab.Shared.Exceptions.Mapper;

public interface IExceptionToResponseMapper
{
    ExceptionResponse Map(Exception exception);
}

internal class ExceptionToResponseMapper : IExceptionToResponseMapper
{
    public ExceptionResponse Map(Exception exception)
    {
        return exception switch
        {
            DomainException ex => new ExceptionResponse(, HttpStatusCode.BadRequest),
            FeatureException ex => new ExceptionResponse(, HttpStatusCode.BadRequest),
            PolicyException ex => new ExceptionResponse(, HttpStatusCode.BadRequest),
            _ => new ExceptionResponse(, HttpStatusCode.InternalServerError)
        };
    }
    
    private record Error(string Code, string Reason);

    private record ErrorsResponse(params Error[] Errors);
}

public record ExceptionResponse(object Response, HttpStatusCode StatusCode);