using FastEndpoints;
using FluentValidation;
using ValueOf;

namespace Confab.Modules.Conferences.Domain.Hosts.ValueObjects;

public class HostDescription : ValueOf<string, HostDescription>
{
}

// public class HostDescriptionValidator : AbstractValidator<HostDescription>
// {
//     public HostDescriptionValidator()
//     {
//         RuleFor(x => x.Value)
//             .MinimumLength(3).WithMessage("Minimum lenght for host description is 3 characters.")
//             .MaximumLength(1000).WithMessage("Maximum lenght for host description is 1000 characters.");
//     }
// }

public class HostDescriptionValidator : Validator<HostDescription>
{
    public HostDescriptionValidator()
    {
        RuleFor(x => x.Value)
            .MinimumLength(3).WithMessage("Minimum lenght for host description is 3 characters.")
            .MaximumLength(1000).WithMessage("Maximum lenght for host description is 1000 characters.");
    }
}