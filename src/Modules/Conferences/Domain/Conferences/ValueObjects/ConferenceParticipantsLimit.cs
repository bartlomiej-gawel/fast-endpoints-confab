

using Confab.Shared.Types;

namespace Confab.Modules.Conferences.Domain.Conferences.ValueObjects;

// public class ConferenceParticipantsLimit : ValueOf<int?, ConferenceParticipantsLimit>
// {
// }
//
// public class ConferenceParticipantsLimitValidator : Validator<ConferenceParticipantsLimit>
// {
//     public ConferenceParticipantsLimitValidator()
//     {
//         RuleFor(x => x.Value)
//             .GreaterThan(0).When(x => x.Value is not null).WithMessage("Participant limit cannot be 0 or below.");
//     }
// }

public class ConferenceParticipantsLimit : BaseValueObject
{
    public int Value { get; }

    public ConferenceParticipantsLimit(int value)
    {
        Value = value;
    }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}