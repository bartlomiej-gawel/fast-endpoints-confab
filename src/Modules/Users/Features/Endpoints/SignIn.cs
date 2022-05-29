using FastEndpoints;
using Microsoft.AspNetCore.Authorization;

namespace Confab.Modules.Users.Features.Endpoints;

internal class SignInRequest
{
    
}

internal class SignInRequestValidator : Validator<SignInRequest>
{
    public SignInRequestValidator()
    {
        
    }
}

[HttpPost("api/users-module/users/signIn"), AllowAnonymous]
internal class SigInEndpoint : Endpoint<SignInRequest>
{
    public override Task HandleAsync(SignInRequest req, CancellationToken ct)
    {
        return base.HandleAsync(req, ct);
    }
}