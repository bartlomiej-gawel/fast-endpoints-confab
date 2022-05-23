using Confab.Modules.Conferences.Domain.Conferences.ValueObjects;
using Confab.Modules.Conferences.Features.Conferences.Exceptions;
using Confab.Modules.Conferences.Infrastructure;
using FastEndpoints;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;

namespace Confab.Modules.Conferences.Features.Conferences.Endpoints;

internal class UpdateConferenceRequest
{
    public Guid ConferenceId { get; init; } = default!;
    public string Name { get; init; } = default!;
    public string Description { get; init; } = default!;
    public string City { get; init; } = default!;
    public string Street { get; init; } = default!;
    public int ParticipantsLimit { get; init; } = default!;
    public DateTime From { get; init; } = default!;
    public DateTime To { get; init; } = default!;
}

internal class UpdateConferenceRequestValidator : Validator<UpdateConferenceRequest>
{
    public UpdateConferenceRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Please specify a name");
        RuleFor(x => x.Description).NotEmpty().WithMessage("Please specify a description");
        RuleFor(x => x.City).NotEmpty().WithMessage("Please specify a city");
        RuleFor(x => x.Street).NotEmpty().WithMessage("Please specify a street");
        RuleFor(x => x.ParticipantsLimit).NotEmpty().WithMessage("Please specify a participants limit");
        RuleFor(x => x.From).NotEmpty().WithMessage("Please specify a start date");
        RuleFor(x => x.To).NotEmpty().WithMessage("Please specify an end date");
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
        var conference = await _dbContext.Conferences.FindAsync(req.ConferenceId);
        if (conference is null)
        {
            throw new ConferenceNotFoundException(req.ConferenceId);
        }
        
        conference.Update(
            new ConferenceName(req.Name),
            new ConferenceDescription(req.Description),
            new ConferenceLocation(req.City, req.Street),
            new ConferenceParticipantsLimit(req.ParticipantsLimit),
            new ConferenceDate(req.From, req.To));

        _dbContext.Conferences.Update(conference);
        await _dbContext.SaveChangesAsync(ct);
        
        await SendOkAsync(ct);
    }
}