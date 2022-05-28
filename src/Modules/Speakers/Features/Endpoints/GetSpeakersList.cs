using Confab.Modules.Speakers.Infrastructure;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Confab.Modules.Speakers.Features.Endpoints;

internal class GetSpeakersListResponse
{
    public Guid SpeakerId { get; init; }
    public string Email { get; init; } = default!;
    public string FullName { get; init; } = default!;
    public string Bio { get; init; } = default!;
    public string AvatarUrl { get; init; } = default!;
}

[HttpGet("api/speakers-module/speakers/getSpeakersList"), AllowAnonymous]
internal class GetSpeakersListEndpoint : EndpointWithoutRequest<List<GetSpeakersListResponse>>
{
    private readonly SpeakersDbContext _dbContext;

    public GetSpeakersListEndpoint(SpeakersDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var response = await _dbContext.Speakers
            .AsNoTracking()
            .Select(x => new GetSpeakersListResponse
            {
                SpeakerId = x.Id.Value,
                Email = x.Email.Value,
                FullName = x.FullName.GetFullName,
                Bio = x.Bio.Value,
                AvatarUrl = x.AvatarUrl.Value
            }).ToListAsync(ct);

        await SendAsync(response, cancellation: ct);
    }
}