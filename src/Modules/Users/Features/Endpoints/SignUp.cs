using Confab.Modules.Users.Domain.ValueObjects;
using FastEndpoints;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;

namespace Confab.Modules.Users.Features.Endpoints;

internal class SignUpRequest
{
    public string Email { get; init; } = default!;
    public string Password { get; init; } = default!;
    public string Role { get; init; } = default!;
}

internal class SignUpRequestValidator : Validator<SignUpRequest>
{
    public SignUpRequestValidator()
    {
        RuleFor(x => x.Email).NotEmpty().WithMessage("Please specify an email.");
        RuleFor(x => x.Password).NotEmpty().WithMessage("Please specify a password.");
    }
}

[HttpPost("api/users-module/users/signUp"), AllowAnonymous]
internal class SignUpEndpoint : Endpoint<SignUpRequest>
{
}