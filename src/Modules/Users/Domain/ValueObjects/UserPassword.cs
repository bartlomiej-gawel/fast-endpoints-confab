using Confab.Shared.Domain;
using Confab.Shared.Validations;
using Throw;

namespace Confab.Modules.Users.Domain.ValueObjects;

internal class UserPassword : BaseValueObject
{
    public string Value { get; }

    public UserPassword(string value)
    {
        value.Throw().IfPasswordNotMatchesRegex();

        Value = value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}