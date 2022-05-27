using Confab.Modules.Speakers.Domain.ValueObjects;
using Confab.Shared.Domain;

namespace Confab.Modules.Speakers.Domain;

internal class Speaker : BaseEntity
{
    public SpeakerId Id { get; private set; }
    public SpeakerEmail Email { get; private set; }
    public SpeakerFullName FullName { get; private set; }
    public SpeakerBio Bio { get; private set; }
    public SpeakerAvatarUrl AvatarUrl { get; private set; }

    private Speaker()
    {
    }

    private Speaker(
        SpeakerEmail email,
        SpeakerFullName fullName,
        SpeakerBio bio,
        SpeakerAvatarUrl avatarUrl)
    {
        Id = new SpeakerId(Guid.NewGuid());
        Email = email;
        FullName = fullName;
        Bio = bio;
        AvatarUrl = avatarUrl;
    }

    public static Speaker Create(
        SpeakerEmail email,
        SpeakerFullName fullName,
        SpeakerBio bio,
        SpeakerAvatarUrl avatarUrl)
    {
        return new Speaker(
            email,
            fullName,
            bio,
            avatarUrl);
    }

    public void Update(
        SpeakerEmail email,
        SpeakerFullName fullName,
        SpeakerBio bio,
        SpeakerAvatarUrl avatarUrl)
    {
        Email = email;
        FullName = fullName;
        Bio = bio;
        AvatarUrl = avatarUrl;
    }
}