using FluentValidation;
using ValueOf;

namespace Confab.Modules.Conferences.Domain.Hosts.ValueObjects;

public class HostName : ValueOf<string, HostName>
{
}

public class HostNameValidator : AbstractValidator<HostName>
{
    public HostNameValidator()
    {
        RuleFor(x => x.Value)
            .MinimumLength(3).WithMessage("Minimum lenght for host name is 3 characters.")
            .MaximumLength(100).WithMessage("Maximum lenght for host name is 100 characters.");
    }
}