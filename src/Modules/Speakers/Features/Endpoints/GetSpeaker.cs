using Confab.Modules.Speakers.Domain.ValueObjects;
using Confab.Modules.Speakers.Features.Exceptions;
using Confab.Modules.Speakers.Infrastructure;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;

namespace Confab.Modules.Speakers.Features.Endpoints;

internal class GetSpeakerRequest
{
    public Guid SpeakerId { get; init; } = default!;
}

internal class GetSpeakerResponse
{
    public Guid SpeakerId { get; init; }
    public string Email { get; init; } = default!;
    public string FullName { get; init; } = default!;
    public string Bio { get; init; } = default!;
    public string AvatarUrl { get; init; } = default!;
}

[HttpGet("api/speakers-module/speakers/getSpeaker/{speakerId:guid}"), AllowAnonymous]
internal class GetSpeakerEndpoint : Endpoint<GetSpeakerRequest, GetSpeakerResponse>
{
    private readonly SpeakersDbContext _dbContext;

    public GetSpeakerEndpoint(SpeakersDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public override async Task HandleAsync(GetSpeakerRequest req, CancellationToken ct)
    {
        var speaker = await _dbContext.Speakers.FindAsync(new SpeakerId(req.SpeakerId));
        if (speaker is null)
        {
            throw new SpeakerNotFoundException(req.SpeakerId);
        }

        var response = new GetSpeakerResponse
        {
            SpeakerId = speaker.Id.Value,
            Email = speaker.Email.Value,
            FullName = speaker.FullName.GetFullName,
            Bio = speaker.Bio.Value,
            AvatarUrl = speaker.AvatarUrl.Value
        };

        await SendAsync(response, cancellation: ct);
    }
}