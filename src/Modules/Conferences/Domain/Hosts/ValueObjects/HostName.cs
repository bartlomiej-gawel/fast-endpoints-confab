using Confab.Shared.Exceptions;
using Confab.Shared.Types;
using Throw;

namespace Confab.Modules.Conferences.Domain.Hosts.ValueObjects;

internal class HostName : BaseValueObject
{
    public string Value { get; }
    
    private HostName(string value)
    {
        Value = value;
    }

    public static HostName Create(string value)
    {
        value.Throw(_ => throw new DomainException("Minimum lenght for host name is 3 characters."))
            .IfShorterThan(3);
        
        value.Throw(_ => throw new DomainException("Maximum lenght for host name is 100 characters."))
            .IfLongerThan(100);

        return new HostName(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}