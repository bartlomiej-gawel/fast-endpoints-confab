using Confab.Shared.Types;

namespace Confab.Modules.Conferences.Domain.Hosts.ValueObjects;

public class HostName : BaseValueObject
{
    public string Value { get; }
    
    public HostName(string value)
    {
        Value = value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}