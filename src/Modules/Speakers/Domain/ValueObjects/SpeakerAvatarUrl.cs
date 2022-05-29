using Confab.Shared.Domain;
using Confab.Shared.Exceptions.CustomExceptions;
using Throw;

namespace Confab.Modules.Speakers.Domain.ValueObjects;

internal class SpeakerAvatarUrl : BaseValueObject
{
    public string Value { get; }

    public SpeakerAvatarUrl(string value)
    {
        value.Throw(_ => throw new DomainException("Please specify a correct speaker avatar url. 3-100 characters."))
            .IfShorterThan(3)
            .IfLongerThan(100);
        
        Value = value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}