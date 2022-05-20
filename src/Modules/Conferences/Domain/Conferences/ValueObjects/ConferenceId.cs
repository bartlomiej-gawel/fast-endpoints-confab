using FluentValidation;
using ValueOf;

namespace Confab.Modules.Conferences.Domain.Conferences.ValueObjects;

public class ConferenceId : ValueOf<Guid, ConferenceId>
{
}

public class ConferenceIdValidator : AbstractValidator<ConferenceId>
{
    public ConferenceIdValidator()
    {
        RuleFor(x => x.Value)
            .NotEmpty().WithMessage("Conference Id cannot be empty.")
            .NotNull().WithMessage("Conference Id cannot be null.");
    }
}