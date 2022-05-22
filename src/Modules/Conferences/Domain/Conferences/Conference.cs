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
        string city,
        string street,
        int participantsLimit,
        DateTime from,
        DateTime to)
    {
        Id = new ConferenceId(Guid.NewGuid());
        HostId = new HostId(hostId);
        Name = new ConferenceName(name);
        Description = new ConferenceDescription(description);
        Location = new ConferenceLocation(city, street);
        ParticipantsLimit = new ConferenceParticipantsLimit(participantsLimit);
        Date = new ConferenceDate(from, to);
    }

    public static Conference Create(
        Guid hostId,
        string name,
        string description,
        string city,
        string street,
        int participantsLimit,
        DateTime from,
        DateTime to)
    {
        return new Conference(
            hostId,
            name,
            description,
            city,
            street,
            participantsLimit,
            from,
            to);
    }

    public void Update(
        string name,
        string description,
        string city,
        string street,
        int participantsLimit,
        DateTime from,
        DateTime to)
    {
        Name = new ConferenceName(name);
        Description = new ConferenceDescription(description);
        Location = new ConferenceLocation(city, street);
        ParticipantsLimit = new ConferenceParticipantsLimit(participantsLimit);
        Date = new ConferenceDate(from, to);
    }

    public void Delete()
    {
        CheckPolicy(new ConferenceDeletionPolicy(Date));
    }
}