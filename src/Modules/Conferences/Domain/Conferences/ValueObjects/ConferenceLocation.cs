using FastEndpoints;
using FluentValidation;
using ValueOf;

namespace Confab.Modules.Conferences.Domain.Conferences.ValueObjects;

public class ConferenceLocation : ValueOf<(string City, string Street), ConferenceLocation>
{
    public string GetCity => Value.City;
    public string GetStreet => Value.Street;
}

public class ConferenceLocationValidator : Validator<ConferenceLocation>
{
    public ConferenceLocationValidator()
    {
        RuleFor(x => x.Value.City)
            .MinimumLength(3).WithMessage("Minimum length for city is 3 characters.")
            .MaximumLength(50).WithMessage("Maximum lenght for city is 50 characters.");
        
        RuleFor(x => x.Value.Street)
            .MinimumLength(3).WithMessage("Minimum length for street is 3 characters.")
            .MaximumLength(50).WithMessage("Maximum lenght for street is 50 characters.");
    }
}