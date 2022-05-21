using FastEndpoints;
using FluentValidation;
using ValueOf;

namespace Confab.Modules.Conferences.Domain.Hosts.ValueObjects;

public class HostId : ValueOf<Guid, HostId>
{
}

public class HostIdValidator : Validator<HostId>
{
    public HostIdValidator()
    {
        RuleFor(x => x.Value)
            .NotEmpty().WithMessage("Host Id cannot be empty.")
            .NotNull().WithMessage("Host Id cannot be null.");
    }
}