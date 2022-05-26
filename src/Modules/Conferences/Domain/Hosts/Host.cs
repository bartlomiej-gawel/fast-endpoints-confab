using Confab.Modules.Conferences.Domain.Conferences;
using Confab.Modules.Conferences.Domain.Hosts.Policies;
using Confab.Modules.Conferences.Domain.Hosts.ValueObjects;
using Confab.Shared.Domain;

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
    
    private Host(HostName name, HostDescription description)
    {
        Id = new HostId(Guid.NewGuid());
        Name = name;
        Description = description;
        Conferences = new List<Conference>();
    }
    
    public static Host Create(HostName name, HostDescription description)
    {
        return new Host(name, description);
    }

    public void Update(HostName name, HostDescription description)
    {
        Name = name;
        Description = description;
    }
    
    public void Delete()
    {
        CheckPolicy(new HostDeletionPolicy(Conferences));
    }
}