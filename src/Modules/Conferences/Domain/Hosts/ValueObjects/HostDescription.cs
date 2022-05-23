using Confab.Shared.Exceptions;
using Confab.Shared.Types;
using Throw;

namespace Confab.Modules.Conferences.Domain.Hosts.ValueObjects;

public class HostDescription : BaseValueObject
{
    public string Value { get; }

    private HostDescription(string value)
    {
        Value = value;
    }

    public static HostDescription Create(string value)
    {
        value.Throw(_ => throw new DomainException("Minimum lenght for host description is 3 characters."))
            .IfShorterThan(3);
        
        value.Throw(_ => throw new DomainException("Maximum lenght for host description is 1000 characters."))
            .IfLongerThan(1000);

        return new HostDescription(value);
    }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}