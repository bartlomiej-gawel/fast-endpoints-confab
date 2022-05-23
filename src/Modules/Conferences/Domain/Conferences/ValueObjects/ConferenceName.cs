using Confab.Shared.Exceptions;
using Confab.Shared.Exceptions.CustomExceptions;
using Confab.Shared.Types;
using Throw;

namespace Confab.Modules.Conferences.Domain.Conferences.ValueObjects;

public class ConferenceName : BaseValueObject
{
    public string Value { get; }

    public ConferenceName(string value)
    {
        value.Throw(_ => throw new DomainException("Please specify a correct conference name. 3-100 characters."))
            .IfShorterThan(3)
            .IfLongerThan(100);

        Value = value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}