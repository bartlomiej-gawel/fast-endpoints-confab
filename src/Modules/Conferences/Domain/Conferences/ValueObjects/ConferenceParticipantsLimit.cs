using Confab.Shared.Domain;
using Confab.Shared.Exceptions.CustomExceptions;
using Throw;

namespace Confab.Modules.Conferences.Domain.Conferences.ValueObjects;

internal class ConferenceParticipantsLimit : BaseValueObject
{
    public int Value { get; }

    public ConferenceParticipantsLimit(int value)
    {
        value.Throw(_ => throw new DomainException("Participant limit cannot be below 0."))
            .IfLessThan(0);

        Value = value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}