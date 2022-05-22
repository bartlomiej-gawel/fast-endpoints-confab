using Confab.Shared.Types;

namespace Confab.Modules.Conferences.Domain.Hosts.ValueObjects;

public class HostDescription : BaseValueObject
{
    public string Value { get; }

    public HostDescription(string value)
    {
        Value = value;
    }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}