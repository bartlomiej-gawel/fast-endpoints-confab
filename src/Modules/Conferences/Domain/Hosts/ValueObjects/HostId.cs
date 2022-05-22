using Confab.Shared.Types;

namespace Confab.Modules.Conferences.Domain.Hosts.ValueObjects;

public class HostId : BaseId
{
    public HostId(Guid value) : base(value)
    {
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}