using Confab.Modules.Speakers.Domain;
using Confab.Modules.Speakers.Domain.ValueObjects;
using Confab.Modules.Speakers.Infrastructure;
using FastEndpoints;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;

namespace Confab.Modules.Speakers.Features.Endpoints;

internal class CreateSpeakerRequest
{
    public string Email { get; init; } = default!;
    public string FirstName { get; init; } = default!;
    public string LastName { get; init; } = default!;
    public string Bio { get; init; } = default!;
    public string AvatarUrl { get; init; } = default!;
}

internal class CreateSpeakerRequestValidator : Validator<CreateSpeakerRequest>
{
    public CreateSpeakerRequestValidator()
    {
        RuleFor(x => x.Email).NotEmpty().WithMessage("Please specify an email");
        RuleFor(x => x.FirstName).NotEmpty().WithMessage("Please specify a first name");
        RuleFor(x => x.LastName).NotEmpty().WithMessage("Please specify a last name");
        RuleFor(x => x.Bio).NotEmpty().WithMessage("Please specify a bio");
        RuleFor(x => x.AvatarUrl).NotEmpty().WithMessage("Please specify an avatar url");
    }
}

[HttpPost("api/speakers-module/speakers/createSpeaker"), AllowAnonymous]
internal class CreateSpeakerEndpoint : Endpoint<CreateSpeakerRequest>
{
    private readonly SpeakersDbContext _dbContext;

    public CreateSpeakerEndpoint(SpeakersDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public override async Task HandleAsync(CreateSpeakerRequest req, CancellationToken ct)
    {
        var speaker = Speaker.Create(
            new SpeakerEmail(req.Email),
            new SpeakerFullName(req.FirstName, req.LastName),
            new SpeakerBio(req.Bio),
            new SpeakerAvatarUrl(req.AvatarUrl));

        await _dbContext.Speakers.AddAsync(speaker, ct);
        await _dbContext.SaveChangesAsync(ct);

        await SendOkAsync(ct);
    }
}