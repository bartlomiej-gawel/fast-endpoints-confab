using Confab.Shared.Domain;
using Confab.Shared.Exceptions.CustomExceptions;
using Throw;

namespace Confab.Modules.Speakers.Domain.ValueObjects;

internal class SpeakerBio : BaseValueObject
{
    public string Value { get; }

    public SpeakerBio(string value)
    {
        value.Throw(_ => throw new DomainException("Please specify a correct bio of speaker. 3-1000 characters."))
            .IfShorterThan(3)
            .IfLongerThan(1000);
        
        Value = value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}