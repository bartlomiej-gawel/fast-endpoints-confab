using Confab.Modules.Speakers.Domain.ValueObjects;
using Confab.Modules.Speakers.Features.Exceptions;
using Confab.Modules.Speakers.Infrastructure;
using FastEndpoints;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;

namespace Confab.Modules.Speakers.Features.Endpoints;

internal class UpdateSpeakerRequest
{
    public Guid SpeakerId { get; init; } = default!;
    public string Email { get; init; } = default!;
    public string FirstName { get; init; } = default!;
    public string LastName { get; init; } = default!;
    public string Bio { get; init; } = default!;
    public string AvatarUrl { get; init; } = default!;
}

internal class UpdateSpeakerRequestValidator : Validator<UpdateSpeakerRequest>
{
    public UpdateSpeakerRequestValidator()
    {
        RuleFor(x => x.Email).NotEmpty().WithMessage("Please specify an email");
        RuleFor(x => x.FirstName).NotEmpty().WithMessage("Please specify a first name");
        RuleFor(x => x.LastName).NotEmpty().WithMessage("Please specify a last name");
        RuleFor(x => x.Bio).NotEmpty().WithMessage("Please specify a bio");
        RuleFor(x => x.AvatarUrl).NotEmpty().WithMessage("Please specify an avatar url");
    }
}

[HttpPut("api/speakers-module/speakers/updateSpeaker/{speakerId:guid}"), AllowAnonymous]
internal class UpdateSpeakerEndpoint : Endpoint<UpdateSpeakerRequest>
{
    private readonly SpeakersDbContext _dbContext;

    public UpdateSpeakerEndpoint(SpeakersDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public override async Task HandleAsync(UpdateSpeakerRequest req, CancellationToken ct)
    {
        var speaker = await _dbContext.Speakers.FindAsync(new SpeakerId(req.SpeakerId));
        if (speaker is null)
        {
            throw new SpeakerNotFoundException(req.SpeakerId);
        }
        
        speaker.Update(
            new SpeakerEmail(req.Email),
            new SpeakerFullName(req.FirstName, req.LastName),
            new SpeakerBio(req.Bio),
            new SpeakerAvatarUrl(req.AvatarUrl));

        _dbContext.Speakers.Update(speaker);
        await _dbContext.SaveChangesAsync(ct);

        await SendOkAsync(ct);
    }
}