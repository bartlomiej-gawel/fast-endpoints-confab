using System.Text.RegularExpressions;
using Confab.Shared.Exceptions.CustomExceptions;
using Throw;

namespace Confab.Shared.Validations;

public static class ThrowValidationExtensions
{
    public static ref readonly Validatable<string> IfEmailNotMatchesRegex(this in Validatable<string> validatable)
    {
        Regex emailRegex = new(
            "",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);
        
        if (!emailRegex.IsMatch(validatable.Value))
        {
            throw new DomainException("Please specify correct email address.");
        }

        return ref validatable;
    }

    public static ref readonly Validatable<string> IfPasswordNotMatchesRegex(this in Validatable<string> validatable)
    {
        Regex passwordRegex = new(
            "",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);

        if (!passwordRegex.IsMatch(validatable.Value))
        {
            throw new DomainException("Please specify correct password.");
        }

        return ref validatable;
    }
}