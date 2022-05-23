using Confab.Shared.Exceptions;
using Confab.Shared.Exceptions.CustomExceptions;
using Confab.Shared.Types;
using Throw;

namespace Confab.Modules.Conferences.Domain.Conferences.ValueObjects;

internal class ConferenceDescription : BaseValueObject
{
    public string Value { get; }

    public ConferenceDescription(string value)
    {
        value.Throw(_ => throw new DomainException("Please specify a correct conference description. 3-1000 characters."))
            .IfShorterThan(3)
            .IfLongerThan(1000);

        Value = value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}