using Confab.Modules.Conferences.Domain.Conferences;
using Confab.Modules.Conferences.Domain.Conferences.ValueObjects;
using Confab.Modules.Conferences.Domain.Hosts.ValueObjects;
using Confab.Modules.Conferences.Infrastructure;
using FastEndpoints;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;

namespace Confab.Modules.Conferences.Features.Conferences.Endpoints;

internal class CreateConferenceRequest
{
    public Guid HostId { get; init; } = default!;
    public string Name { get; init; } = default!;
    public string Description { get; init; } = default!;
    public string City { get; init; } = default!;
    public string Street { get; init; } = default!;
    public int ParticipantsLimit { get; init; } = default!;
    public DateTime From { get; init; } = default!;
    public DateTime To { get; init; } = default!;
}

internal class CreateConferenceRequestValidator : Validator<CreateConferenceRequest>
{
    public CreateConferenceRequestValidator()
    {
        RuleFor(x => x.HostId).NotEmpty().WithMessage("Please specify a host identifier");
        RuleFor(x => x.Name).NotEmpty().WithMessage("Please specify a name");
        RuleFor(x => x.Description).NotEmpty().WithMessage("Please specify a description");
        RuleFor(x => x.City).NotEmpty().WithMessage("Please specify a city");
        RuleFor(x => x.Street).NotEmpty().WithMessage("Please specify a street");
        RuleFor(x => x.ParticipantsLimit).NotEmpty().WithMessage("Please specify a participants limit");
        RuleFor(x => x.From).NotEmpty().WithMessage("Please specify a start date");
        RuleFor(x => x.To).NotEmpty().WithMessage("Please specify an end date");
    }
}

[HttpPost("api/conferences-module/conferences/createConference"), AllowAnonymous]
internal class CreateConferenceEndpoint : Endpoint<CreateConferenceRequest>
{
    private readonly ConferencesDbContext _dbContext;

    public CreateConferenceEndpoint(ConferencesDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public override async Task HandleAsync(CreateConferenceRequest req, CancellationToken ct)
    {
        var hostId = new HostId(req.HostId);
        var name = new ConferenceName(req.Name);
        var description = new ConferenceDescription(req.Description);
        var location = new ConferenceLocation(req.City, req.Street);
        var participantsLimit = new ConferenceParticipantsLimit(req.ParticipantsLimit);
        var date = new ConferenceDate(req.From, req.To);
        
        var conference = Conference.Create(hostId, name, description, location, participantsLimit, date);

        await _dbContext.Conferences.AddAsync(conference, ct);
        await _dbContext.SaveChangesAsync(ct);

        await SendOkAsync(ct);
    }
}