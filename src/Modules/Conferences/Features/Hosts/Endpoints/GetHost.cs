using Confab.Modules.Conferences.Features.Hosts.Exceptions;
using Confab.Modules.Conferences.Infrastructure;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Confab.Modules.Conferences.Features.Hosts.Endpoints;

internal class GetHostRequest
{
    public Guid HostId { get; set; }
}

internal class GetHostResponse
{
    public Guid HostId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public IReadOnlyList<ConferenceDto> Conferences { get; set; }
    
    internal class ConferenceDto
    {
        public Guid ConferenceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int? ParticipantsLimit { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
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
            .Include(x => x.Conferences)
            .FirstOrDefaultAsync(x => x.Id.Value == req.HostId, ct);

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
                City = conference.Location.Value.City,
                Street = conference.Location.Value.Street,
                ParticipantsLimit = conference.ParticipantsLimit.Value,
                From = conference.Date.Value.From,
                To = conference.Date.Value.To
            }).ToList()
        };

        await SendAsync(response, cancellation: ct);
    }
}