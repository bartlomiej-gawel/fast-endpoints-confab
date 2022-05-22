using Confab.Shared.Types;

namespace Confab.Modules.Conferences.Domain.Conferences.ValueObjects;

// public class ConferenceDate : ValueOf<(DateTime From, DateTime To), ConferenceDate>
// {
// }
//
// public class ConferenceDateValidator : Validator<ConferenceDate>
// {
//     public ConferenceDateValidator()
//     {
//         RuleFor(x => x.Value.From)
//             .GreaterThan(DateTime.UtcNow).WithMessage("Conference start date cannot be yesterday or earlier.");
//
//         RuleFor(x => x.Value.To)
//             .GreaterThanOrEqualTo(x => x.Value.From).WithMessage("Conference end date cannot be before start.");
//     }
// }

public class ConferenceDate : BaseValueObject
{
    public DateTime From { get; }
    public DateTime To { get; }

    public ConferenceDate(DateTime from, DateTime to)
    {
        From = from;
        To = to;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return From;
        yield return To;
    }
}