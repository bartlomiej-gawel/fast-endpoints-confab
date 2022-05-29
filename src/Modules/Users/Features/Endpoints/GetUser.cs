using FastEndpoints;
using Microsoft.AspNetCore.Authorization;

namespace Confab.Modules.Users.Features.Endpoints;

internal class GetUserResponse
{
    
}

[HttpGet("api/users-module/users/getUser"), AllowAnonymous]
internal class GetUserEndpoint : EndpointWithoutRequest<GetUserResponse>
{
    public override Task HandleAsync(CancellationToken ct)
    {
        return base.HandleAsync(ct);
    }
}