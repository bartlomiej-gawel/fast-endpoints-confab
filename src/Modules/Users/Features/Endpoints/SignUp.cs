using FastEndpoints;
using Microsoft.AspNetCore.Authorization;

namespace Confab.Modules.Users.Features.Endpoints;

internal class SignUpRequest
{
    
}

internal class SignUpRequestValidator : Validator<SignUpRequest>
{
    public SignUpRequestValidator()
    {
        
    }
}

[HttpPost("api/users-module/users/signUp"), AllowAnonymous]
internal class SignUpEndpoint : Endpoint<SignUpRequest>
{
    public override Task HandleAsync(SignUpRequest req, CancellationToken ct)
    {
        return base.HandleAsync(req, ct);
    }
}