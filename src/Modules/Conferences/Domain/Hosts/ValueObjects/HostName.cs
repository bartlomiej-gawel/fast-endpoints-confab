using Confab.Shared.Exceptions.CustomExceptions;
using Confab.Shared.Types;
using Throw;

namespace Confab.Modules.Conferences.Domain.Hosts.ValueObjects;

internal class HostName : BaseValueObject
{
    public string Value { get; }
    
    public HostName(string value)
    {
        value.Throw(_ => throw new DomainException("Please specify a correct host name. 3-100 characters."))
            .IfShorterThan(3)
            .IfLongerThan(1000);
        
        Value = value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}