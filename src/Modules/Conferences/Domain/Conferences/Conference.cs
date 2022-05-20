using Confab.Modules.Conferences.Domain.Conferences.ValueObjects;
using Confab.Modules.Conferences.Domain.Hosts.ValueObjects;

namespace Confab.Modules.Conferences.Domain.Conferences;

public class Conference
{
    public ConferenceId Id { get; private set; }

    public HostId HostId { get; private set; }

    public ConferenceName Name { get; private set; }

    public ConferenceDescription Description { get; private set; }

    public ConferenceLocation Location { get; set; }

    public ConferenceParticipantsLimit ConferenceParticipantsLimit { get; private set; }

    public ConferenceDate Date { get; private set; }

    private Conference()
    {
    }

    private Conference(
        Guid hostId,
        string name,
        string description,
        string city,
        string street)
    {
        Id = ConferenceId.From(Guid.NewGuid());
        HostId = HostId.From(hostId);
        Name = ConferenceName.From(name);
        Description = ConferenceDescription.From(description);
        Location = ConferenceLocation.Fro;
    }
}