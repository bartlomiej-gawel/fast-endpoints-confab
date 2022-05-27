using Confab.Shared.Domain;

namespace Confab.Modules.Speakers.Domain.ValueObjects;

internal class SpeakerId : BaseId
{
    public SpeakerId(Guid value) : base(value)
    {
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}