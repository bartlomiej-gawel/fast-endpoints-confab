
using Confab.Shared.Types;

namespace Confab.Modules.Conferences.Domain.Conferences.ValueObjects;

//
//
// public class ConferenceName : ValueOf<string, ConferenceName>
// {
// }
//
// public class ConferenceNameValidator : Validator<ConferenceName>
// {
//     public ConferenceNameValidator()
//     {
//         RuleFor(x => x.Value)
//             .MinimumLength(3).WithMessage("Minimum lenght for conference name is 3 characters.")
//             .MaximumLength(100).WithMessage("Maximum lenght for conference name is 100 characters.");
//     }
// }

public class ConferenceName : BaseValueObject
{
    public string Value { get; }
    
    public ConferenceName(string value)
    {
        Value = value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}