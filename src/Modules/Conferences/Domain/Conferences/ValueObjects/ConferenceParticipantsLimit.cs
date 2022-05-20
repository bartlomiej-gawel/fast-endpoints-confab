using FluentValidation;
using ValueOf;

namespace Confab.Modules.Conferences.Domain.Conferences.ValueObjects;

public class ConferenceParticipantsLimit : ValueOf<int?, ConferenceParticipantsLimit>
{
}

public class ConferenceParticipantsLimitValidator : AbstractValidator<ConferenceParticipantsLimit>
{
    public ConferenceParticipantsLimitValidator()
    {
        RuleFor(x => x.Value)
            .GreaterThan(0).When(x => x.Value is not null).WithMessage("Participant limit cannot be 0 or below.");
    }
}