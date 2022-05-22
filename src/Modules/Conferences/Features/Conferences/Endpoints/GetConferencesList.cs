using Confab.Modules.Conferences.Infrastructure;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Confab.Modules.Conferences.Features.Conferences.Endpoints;

internal class GetConferencesListResponse
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

[HttpGet("api/conferences-module/conferences/getConferencesList"), AllowAnonymous]
internal class GetConferencesListEndpoint : EndpointWithoutRequest<List<GetConferencesListResponse>>
{
    private readonly ConferencesDbContext _dbContext;

    public GetConferencesListEndpoint(ConferencesDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var response = await _dbContext.Conferences
            .AsNoTracking()
            .Select(x => new GetConferencesListResponse
            {
                ConferenceId = x.Id.Value,
                HostId = x.HostId.Value,
                Name = x.Name.Value,
                Description = x.Description.Value,
                City = x.Location.City,
                Street = x.Location.Street,
                ParticipantsLimit = x.ParticipantsLimit.Value,
                From = x.Date.From,
                To = x.Date.To
            }).ToListAsync(ct);
        
        await SendAsync(response, cancellation: ct);
    }
}