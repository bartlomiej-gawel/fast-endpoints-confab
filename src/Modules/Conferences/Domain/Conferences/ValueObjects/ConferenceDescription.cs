using Confab.Shared.Types;

namespace Confab.Modules.Conferences.Domain.Conferences.ValueObjects;

// public class ConferenceDescription : ValueOf<string, ConferenceDescription>
// {
//     // public static implicit operator string(Nit nit) => nit.Value;
//     // public static implicit operator Nit(string nit) => From(nit);
// }
//
// public class ConferenceDescriptionValidator : Validator<ConferenceDescription>
// {
//     public ConferenceDescriptionValidator()
//     {
//         RuleFor(x => x.Value)
//             .MinimumLength(3).WithMessage("Minimum lenght for conference description is 3 characters.")
//             .MaximumLength(1000).WithMessage("Maximum lenght for conference description is 1000 characters.");
//     }
// }

public class ConferenceDescription : BaseValueObject
{
    public string Value { get; }

    public ConferenceDescription(string value)
    {
        Value = value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}