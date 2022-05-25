using Confab.Modules.Conferences.Domain.Hosts.ValueObjects;
using Confab.Modules.Conferences.Features.Hosts.Exceptions;
using Confab.Modules.Conferences.Infrastructure;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Confab.Modules.Conferences.Features.Hosts.Endpoints;

internal class GetHostRequest
{
    public Guid HostId { get; init; } = default!;
}

internal class GetHostResponse
{
    public Guid HostId { get; init; }
    public string Name { get; init; } = default!;
    public string Description { get; init; } = default!;
    public IEnumerable<ConferenceDto> Conferences { get; init; } = default!;
    
    internal class ConferenceDto
    {
        public Guid ConferenceId { get; init; }
        public string Name { get; init; } = default!;
        public string Description { get; init; } = default!;
        public string City { get; init; } = default!;
        public string Street { get; init; } = default!;
        public int ParticipantsLimit { get; init; }
        public DateTime From { get; init; }
        public DateTime To { get; init; }
    }
}

[HttpGet("api/conferences-module/hosts/getHost/{hostId:guid}"), AllowAnonymous]
internal class GetHostEndpoint : Endpoint<GetHostRequest, GetHostResponse>
{
    private readonly ConferencesDbContext _dbContext;

    public GetHostEndpoint(ConferencesDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public override async Task HandleAsync(GetHostRequest req, CancellationToken ct)
    {
        var host = await _dbContext.Hosts
            .AsNoTracking()
            .Include(host => host.Conferences)
            .FirstOrDefaultAsync(host => host.Id == new HostId(req.HostId), ct);

        if (host is null)
        {
            throw new HostNotFoundException(req.HostId);
        }

        var response = new GetHostResponse
        {
            HostId = host.Id.Value,
            Name = host.Name.Value,
            Description = host.Description.Value,
            Conferences = host.Conferences.Select(conference => new GetHostResponse.ConferenceDto
            {
                ConferenceId = conference.Id.Value,
                Name = conference.Name.Value,
                Description = conference.Description.Value,
                City = conference.Location.City,
                Street = conference.Location.Street,
                ParticipantsLimit = conference.ParticipantsLimit.Value,
                From = conference.Date.From,
                To = conference.Date.To
            }).ToList()
        };

        await SendAsync(response, cancellation: ct);
    }
}