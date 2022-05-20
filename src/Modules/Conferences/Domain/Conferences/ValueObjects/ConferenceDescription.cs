using FluentValidation;
using ValueOf;

namespace Confab.Modules.Conferences.Domain.Conferences.ValueObjects;

public class ConferenceDescription : ValueOf<string, ConferenceDescription>
{
}

public class ConferenceDescriptionValidator : AbstractValidator<ConferenceDescription>
{
    public ConferenceDescriptionValidator()
    {
        RuleFor(x => x.Value)
            .MinimumLength(3).WithMessage("Minimum lenght for conference description is 3 characters.")
            .MaximumLength(1000).WithMessage("Maximum lenght for conference description is 1000 characters.");
    }
}