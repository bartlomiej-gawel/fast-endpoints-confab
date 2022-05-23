using Confab.Modules.Conferences.Domain.Hosts;
using Confab.Modules.Conferences.Domain.Hosts.ValueObjects;
using Confab.Modules.Conferences.Infrastructure;
using FastEndpoints;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;

namespace Confab.Modules.Conferences.Features.Hosts.Endpoints;

internal class CreateHostRequest
{
    public string Name { get; } = default!;
    public string Description { get; } = default!;
}

internal class CreateHostRequestValidator : Validator<CreateHostRequest>
{
    public CreateHostRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Host name cannot be empty.");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Host description cannot be empty.");
    }
}

[HttpPost("api/conferences-module/hosts/createHost"), AllowAnonymous]
internal class CreateHostEndpoint : Endpoint<CreateHostRequest>
{
    private readonly ConferencesDbContext _dbContext;

    public CreateHostEndpoint(ConferencesDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public override async Task HandleAsync(CreateHostRequest req, CancellationToken ct)
    {
        var host = Host.Create(
            HostName.Create(req.Name),
            HostDescription.Create(req.Description));

        await _dbContext.Hosts.AddAsync(host, ct);
        await _dbContext.SaveChangesAsync(ct);

        await SendOkAsync(ct);
    }
}