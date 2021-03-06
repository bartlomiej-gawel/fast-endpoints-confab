using Confab.Modules.Conferences.Domain.Conferences.Policies;
using Confab.Modules.Conferences.Domain.Conferences.ValueObjects;
using Confab.Modules.Conferences.Domain.Hosts.ValueObjects;
using Confab.Shared.Domain;

namespace Confab.Modules.Conferences.Domain.Conferences;

internal class Conference : BaseEntity
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
        HostId hostId,
        ConferenceName name,
        ConferenceDescription description,
        ConferenceLocation location,
        ConferenceParticipantsLimit participantsLimit,
        ConferenceDate date)
    {
        Id = new ConferenceId(Guid.NewGuid());
        HostId = hostId;
        Name = name;
        Description = description;
        Location = location;
        ParticipantsLimit = participantsLimit;
        Date = date;
    }

    public static Conference Create(
        HostId hostId,
        ConferenceName name,
        ConferenceDescription description,
        ConferenceLocation location,
        ConferenceParticipantsLimit participantsLimit,
        ConferenceDate date)
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
        ConferenceName name,
        ConferenceDescription description,
        ConferenceLocation location,
        ConferenceParticipantsLimit participantsLimit,
        ConferenceDate date)
    {
        Name = name;
        Description = description;
        Location = location;
        ParticipantsLimit = participantsLimit;
        Date = date;
    }

    public void Delete()
    {
        CheckPolicy(new ConferenceDeletionPolicy(Date, ParticipantsLimit));
    }
}