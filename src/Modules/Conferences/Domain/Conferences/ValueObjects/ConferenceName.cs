using Confab.Shared.Domain;
using Confab.Shared.Exceptions.CustomExceptions;
using Throw;

namespace Confab.Modules.Conferences.Domain.Conferences.ValueObjects;

internal class ConferenceName : BaseValueObject
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