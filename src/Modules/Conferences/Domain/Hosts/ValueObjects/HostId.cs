using Confab.Shared.Domain;

namespace Confab.Modules.Conferences.Domain.Hosts.ValueObjects;

internal class HostId : BaseId
{
    public HostId(Guid value) : base(value)
    {
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}