using Confab.Modules.Conferences.Features.Hosts.Exceptions;
using Confab.Modules.Conferences.Infrastructure;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Confab.Modules.Conferences.Features.Hosts.Endpoints;

internal class DeleteHostRequest
{
    public Guid HostId { get; set; }
}

[HttpDelete("api/conferences-module/hosts/deleteHost/{hostId:guid}"), AllowAnonymous]
internal class DeleteHostEndpoint : Endpoint<DeleteHostRequest>
{
    private readonly ConferencesDbContext _dbContext;
    
    public DeleteHostEndpoint(ConferencesDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public override async Task HandleAsync(DeleteHostRequest req, CancellationToken ct)
    {
        var host = await _dbContext.Hosts
            .AsNoTracking()
            .FirstOrDefaultAsync(host => host.Id.Value == req.HostId, ct);
        
        if (host is null)
        {
            throw new HostNotFoundException(req.HostId);
        }
        
        host.Delete();

        _dbContext.Hosts.Remove(host);
        await _dbContext.SaveChangesAsync(ct);

        await SendNoContentAsync(ct);
    }
}