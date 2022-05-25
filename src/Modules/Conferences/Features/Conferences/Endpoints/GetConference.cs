using Confab.Modules.Conferences.Domain.Conferences.ValueObjects;
using Confab.Modules.Conferences.Features.Conferences.Exceptions;
using Confab.Modules.Conferences.Infrastructure;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;

namespace Confab.Modules.Conferences.Features.Conferences.Endpoints;

internal class GetConferenceRequest
{
    public Guid ConferenceId { get; init; } = default!;
}

internal class GetConferenceResponse
{
    public Guid ConferenceId { get; init; }
    public Guid HostId { get; init; }
    public string Name { get; init; } = default!;
    public string Description { get; init; } = default!;
    public string City { get; init; } = default!;
    public string Street { get; init; } = default!;
    public int ParticipantsLimit { get; init; }
    public DateTime From { get; init; }
    public DateTime To { get; init; }
}

[HttpGet("api/conferences-module/conferences/getConference/{conferenceId:guid}"), AllowAnonymous]
internal class GetConferenceEndpoint : Endpoint<GetConferenceRequest, GetConferenceResponse>
{
    private readonly ConferencesDbContext _dbContext;

    public GetConferenceEndpoint(ConferencesDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public override async Task HandleAsync(GetConferenceRequest req, CancellationToken ct)
    {
        var conference = await _dbContext.Conferences.FindAsync(new ConferenceId(req.ConferenceId));
        if (conference is null)
        {
            throw new ConferenceNotFoundException(req.ConferenceId);
        }

        var response = new GetConferenceResponse
        {
            ConferenceId = conference.Id.Value,
            HostId = conference.HostId.Value,
            Name = conference.Name.Value,
            Description = conference.Description.Value,
            City = conference.Location.City,
            Street = conference.Location.Street,
            ParticipantsLimit = conference.ParticipantsLimit.Value,
            From = conference.Date.From,
            To = conference.Date.To
        };
        
        await SendAsync(response, cancellation: ct);
    }
}