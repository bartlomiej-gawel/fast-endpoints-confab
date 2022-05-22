using Confab.Modules.Conferences.Domain.Conferences;
using Confab.Modules.Conferences.Infrastructure;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;

namespace Confab.Modules.Conferences.Features.Conferences.Endpoints;

internal class CreateConferenceRequest
{
    public Guid HostId { get; }
    public string Name { get; }
    public string Description { get; }
    public string City { get; }
    public string Street { get; }
    public int ParticipantsLimit { get; }
    public DateTime From { get; }
    public DateTime To { get; }
}

internal class CreateConferenceRequestValidator : Validator<CreateConferenceRequest>
{
    public CreateConferenceRequestValidator()
    {
    }
}

[HttpPost("api/conferences-module/conferences/createConference"), AllowAnonymous]
internal class CreateConferenceEndpoint : Endpoint<CreateConferenceRequest>
{
    private readonly ConferencesDbContext _dbContext;

    public CreateConferenceEndpoint(ConferencesDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public override async Task HandleAsync(CreateConferenceRequest req, CancellationToken ct)
    {
        var conference = Conference.Create(
            req.HostId,
            req.Name,
            req.Description,
            req.City,
            req.Street,
            req.ParticipantsLimit,
            req.From,
            req.To);

        await _dbContext.Conferences.AddAsync(conference, ct);
        await _dbContext.SaveChangesAsync(ct);

        await SendOkAsync(ct);
    }
}