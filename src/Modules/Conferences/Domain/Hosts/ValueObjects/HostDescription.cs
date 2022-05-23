using Confab.Shared.Exceptions;
using Confab.Shared.Types;
using Throw;

namespace Confab.Modules.Conferences.Domain.Hosts.ValueObjects;

internal class HostDescription : BaseValueObject
{
    public string Value { get; }

    public HostDescription(string value)
    {
        value.Throw(_ => throw new DomainException("Please specify a correct host description. 3-1000 characters."))
            .IfShorterThan(3)
            .IfLongerThan(1000);
        
        Value = value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}