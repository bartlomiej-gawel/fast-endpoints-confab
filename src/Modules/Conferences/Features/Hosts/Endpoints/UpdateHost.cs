using Confab.Modules.Conferences.Domain.Hosts.ValueObjects;
using Confab.Modules.Conferences.Features.Hosts.Exceptions;
using Confab.Modules.Conferences.Infrastructure;
using FastEndpoints;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;

namespace Confab.Modules.Conferences.Features.Hosts.Endpoints;

internal class UpdateHostRequest
{
    public Guid HostId { get; init; } = default!;
    public string Name { get; init; } = default!;
    public string Description { get; init; } = default!;
}

internal class UpdateHostRequestValidator : Validator<UpdateHostRequest>
{
    public UpdateHostRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Host name cannot be empty.");
        RuleFor(x => x.Description).NotEmpty().WithMessage("Host description cannot be empty.");
    }
}

[HttpPut("api/conferences-module/hosts/updateHost/{hostId:guid}"), AllowAnonymous]
internal class UpdateHostEndpoint : Endpoint<UpdateHostRequest>
{
    private readonly ConferencesDbContext _dbContext;

    public UpdateHostEndpoint(ConferencesDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public override async Task HandleAsync(UpdateHostRequest req, CancellationToken ct)
    {
        var host = await _dbContext.Hosts.FindAsync(new HostId(req.HostId));
        if (host is null)
        {
            throw new HostNotFoundException(req.HostId);
        }
        
        host.Update(
            new HostName(req.Name),
            new HostDescription(req.Description));

        _dbContext.Hosts.Update(host);
        await _dbContext.SaveChangesAsync(ct);

        await SendOkAsync(ct);
    }
}