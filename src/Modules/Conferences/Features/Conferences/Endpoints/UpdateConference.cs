using Confab.Modules.Conferences.Features.Conferences.Exceptions;
using Confab.Modules.Conferences.Infrastructure;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Confab.Modules.Conferences.Features.Conferences.Endpoints;

internal class UpdateConferenceRequest
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

internal class UpdateConferenceRequestValidator : Validator<UpdateConferenceRequest>
{
    public UpdateConferenceRequestValidator()
    {
    }
}

[HttpPut("api/conferences-module/conferences/updateConference/{conferenceId:guid}"), AllowAnonymous]
internal class UpdateConferenceEndpoint : Endpoint<UpdateConferenceRequest>
{
    private readonly ConferencesDbContext _dbContext;

    public UpdateConferenceEndpoint(ConferencesDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public override async Task HandleAsync(UpdateConferenceRequest req, CancellationToken ct)
    {
        var conference = await _dbContext.Conferences
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id.Value == req.ConferenceId, ct);

        if (conference is null)
        {
            throw new ConferenceNotFoundException(req.ConferenceId);
        }
        
        conference.Update(
            req.Name,
            req.Description,
            req.City,
            req.Street,
            req.ParticipantsLimit,
            req.From,
            req.To);

        _dbContext.Conferences.Update(conference);
        await _dbContext.SaveChangesAsync(ct);
        
        await SendOkAsync(ct);
    }
}