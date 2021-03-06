using Confab.Shared.Domain;
using Confab.Shared.Validations;
using Throw;

namespace Confab.Modules.Speakers.Domain.ValueObjects;

internal class SpeakerEmail : BaseValueObject
{
    public string Value { get; }

    public SpeakerEmail(string value)
    {
        value.Throw().IfEmailNotMatchesRegex();
        
        Value = value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}