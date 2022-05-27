using System.Text.RegularExpressions;
using Confab.Shared.Domain;
using Confab.Shared.Exceptions.CustomExceptions;
using Throw;

namespace Confab.Modules.Speakers.Domain.ValueObjects;

internal class SpeakerEmail : BaseValueObject
{
    public string Value { get; }

    public SpeakerEmail(string value)
    {
        value.Throw().IfEmailNotMatchesRegex();
        
        Value = value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}

internal static class ValidatableEmailExtension
{
    public static ref readonly Validatable<string> IfEmailNotMatchesRegex(this in Validatable<string> validatable)
    {
        Regex emailRegex = new(
            "^[\\w!#$%&’*+/=?`{|}~^-]+(?:\\.[\\w!#$%&’*+/=?`{|}~^-]+)*@(?:[a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);
        
        if (!emailRegex.IsMatch(validatable.Value))
        {
            throw new DomainException("Please specify correct email address.");
        }

        return ref validatable;
    }
}