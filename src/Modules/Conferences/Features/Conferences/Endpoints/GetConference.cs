using Confab.Modules.Conferences.Features.Conferences.Exceptions;
using Confab.Modules.Conferences.Infrastructure;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Confab.Modules.Conferences.Features.Conferences.Endpoints;

internal class GetConferenceRequest
{
    public Guid ConferenceId { get; set; }
}

internal class GetConferenceResponse
{
    public Guid ConferenceId { get; set; }
    public Guid HostId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public int ParticipantsLimit { get; set; }
    public DateTime From { get; set; }
    public DateTime To { get; set; }
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
        var conference = await _dbContext.Conferences
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id.Value == req.ConferenceId, ct);

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