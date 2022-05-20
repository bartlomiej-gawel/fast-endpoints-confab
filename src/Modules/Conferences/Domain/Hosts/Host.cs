using Confab.Modules.Conferences.Domain.Conferences;
using Confab.Modules.Conferences.Domain.Hosts.ValueObjects;

namespace Confab.Modules.Conferences.Domain.Hosts;

public class Host
{
    public HostId Id { get; private set; }

    public HostName Name { get; private set; }

    public HostDescription Description { get; private set; }
    
    public List<Conference> Conferences { get; private set; }

    private Host()
    {
        Conferences = new List<Conference>();
    }
    
    private Host(string name, string description)
    {
        Id = HostId.From(Guid.NewGuid());
        Name = HostName.From(name);
        Description = HostDescription.From(description);
        Conferences = new List<Conference>();
    }
    
    public static Host Create(string name, string description)
    {
        return new Host(name, description);
    }

    public void Update(string name, string description)
    {
        Name = HostName.From(name);
        Description = HostDescription.From(description);
    }
    
    public void Delete()
    {
    }
}