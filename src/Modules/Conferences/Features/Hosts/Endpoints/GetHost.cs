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
    public IEnumerable<ConferenceDto> Conferences { get; set; }
    
    internal class ConferenceDto
    {
        public Guid ConferenceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int ParticipantsLimit { get; set; }
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
            .Include(host => host.Conferences)
            .FirstOrDefaultAsync(host => host.Id.Value == req.HostId, ct);

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