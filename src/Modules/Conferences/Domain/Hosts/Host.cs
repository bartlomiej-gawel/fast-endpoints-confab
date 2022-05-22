using Confab.Modules.Conferences.Domain.Conferences;
using Confab.Modules.Conferences.Domain.Hosts.Policies;
using Confab.Modules.Conferences.Domain.Hosts.ValueObjects;
using Confab.Shared.Types;

namespace Confab.Modules.Conferences.Domain.Hosts;

internal class Host : BaseEntity
{
    public HostId Id { get; private set; }
    public HostName Name { get; private set; }
    public HostDescription Description { get; private set; }
    public List<Conference> Conferences { get; private set; }

    private Host()
    {
    }
    
    private Host(string name, string description)
    {
        Id = new HostId(Guid.NewGuid());
        Name = new HostName(name);
        Description = new HostDescription(description);
        Conferences = new List<Conference>();
    }
    
    public static Host Create(string name, string description)
    {
        return new Host(name, description);
    }

    public void Update(string name, string description)
    {
        Name = new HostName(name);
        Description = new HostDescription(description);
    }
    
    public void Delete()
    {
        CheckPolicy(new HostDeletionPolicy(Conferences));
    }
}