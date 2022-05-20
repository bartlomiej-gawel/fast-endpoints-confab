using Confab.Modules.Conferences.Domain.Conferences.Policies;
using Confab.Modules.Conferences.Domain.Conferences.ValueObjects;
using Confab.Modules.Conferences.Domain.Hosts.ValueObjects;
using Confab.Shared.Types;

namespace Confab.Modules.Conferences.Domain.Conferences;

public class Conference : BaseEntity
{
    public ConferenceId Id { get; private set; }

    public HostId HostId { get; private set; }

    public ConferenceName Name { get; private set; }

    public ConferenceDescription Description { get; private set; }

    public ConferenceLocation Location { get; private set; }

    public ConferenceParticipantsLimit ParticipantsLimit { get; private set; }

    public ConferenceDate Date { get; private set; }

    private Conference()
    {
    }

    private Conference(
        Guid hostId,
        string name,
        string description,
        (string city, string street) location,
        int? participantsLimit,
        (DateTime startDate, DateTime endDate) date)
    {
        Id = ConferenceId.From(Guid.NewGuid());
        HostId = HostId.From(hostId);
        Name = ConferenceName.From(name);
        Description = ConferenceDescription.From(description);
        Location = ConferenceLocation.From(location);
        ParticipantsLimit = ConferenceParticipantsLimit.From(participantsLimit);
        Date = ConferenceDate.From(date);
    }

    public static Conference Create(
        Guid hostId,
        string name,
        string description,
        (string city, string street) location,
        int? participantsLimit,
        (DateTime startDate, DateTime endDate) date)
    {
        return new Conference(
            hostId,
            name,
            description,
            location,
            participantsLimit,
            date);
    }

    public void Update(
        string name,
        string description,
        (string city, string street) location,
        int? participantsLimit,
        (DateTime startDate, DateTime endDate) date)
    {
        Name = ConferenceName.From(name);
        Description = ConferenceDescription.From(description);
        Location = ConferenceLocation.From(location);
        ParticipantsLimit = ConferenceParticipantsLimit.From(participantsLimit);
        Date = ConferenceDate.From(date);
    }

    public void Delete()
    {
        CheckPolicy(new ConferenceDeletionPolicy(Date));
    }
}