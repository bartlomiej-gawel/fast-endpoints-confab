using FastEndpoints;
using FluentValidation;
using ValueOf;

namespace Confab.Modules.Conferences.Domain.Conferences.ValueObjects;

public class ConferenceName : ValueOf<string, ConferenceName>
{
}

public class ConferenceNameValidator : Validator<ConferenceName>
{
    public ConferenceNameValidator()
    {
        RuleFor(x => x.Value)
            .MinimumLength(3).WithMessage("Minimum lenght for conference name is 3 characters.")
            .MaximumLength(100).WithMessage("Maximum lenght for conference name is 100 characters.");
    }
}