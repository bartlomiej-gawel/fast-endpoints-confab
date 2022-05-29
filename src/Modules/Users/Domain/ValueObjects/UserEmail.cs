using Confab.Shared.Domain;
using Confab.Shared.Validations;
using Throw;

namespace Confab.Modules.Users.Domain.ValueObjects;

internal class UserEmail : BaseValueObject
{
    public string Value { get; }

    public UserEmail(string value)
    {
        value.Throw().IfEmailNotMatchesRegex();
        
        Value = value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}