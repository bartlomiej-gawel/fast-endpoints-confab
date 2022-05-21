using Confab.Modules.Conferences.Infrastructure;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Confab.Modules.Conferences.Features.Hosts.Endpoints;

internal class GetHostsListResponse
{
    public Guid HostId { get; set; }
    public string HostName { get; set; }
    public string HostDescription { get; set; }
}

[HttpGet("api/conferences-module/hosts/getHostsList"), AllowAnonymous]
internal class GetHostsListEndpoint : EndpointWithoutRequest<List<GetHostsListResponse>>
{
    private readonly ConferencesDbContext _dbContext;

    public GetHostsListEndpoint(ConferencesDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public override async Task HandleAsync(CancellationToken ct)
    {
        var response = await _dbContext.Hosts
            .AsNoTracking()
            .Select(host => new GetHostsListResponse
            {
                HostId = host.Id.Value,
                HostName = host.Name.Value,
                HostDescription = host.Description.Value
            }).ToListAsync(ct);

        await SendAsync(response, cancellation: ct);
    }
}