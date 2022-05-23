using Confab.Modules.Conferences.Features.Conferences.Exceptions;
using Confab.Modules.Conferences.Infrastructure;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Confab.Modules.Conferences.Features.Conferences.Endpoints;

internal class DeleteConferenceRequest
{
    public Guid ConferenceId { get; set; }
}

[HttpDelete("api/conferences-module/conferences/deleteConference/{conferenceId:guid}"), AllowAnonymous]
internal class DeleteConferenceEndpoint : Endpoint<DeleteConferenceRequest>
{
    private readonly ConferencesDbContext _dbContext;

    public DeleteConferenceEndpoint(ConferencesDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public override async Task HandleAsync(DeleteConferenceRequest req, CancellationToken ct)
    {
        var conference = await _dbContext.Conferences.FindAsync(req.ConferenceId);
        if (conference is null)
        {
            throw new ConferenceNotFoundException(req.ConferenceId);
        }
        
        conference.Delete();

        _dbContext.Conferences.Remove(conference);
        await _dbContext.SaveChangesAsync(ct);

        await SendNoContentAsync(ct);
    }
}
