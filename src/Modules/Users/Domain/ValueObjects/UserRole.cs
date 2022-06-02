using Confab.Shared.Domain;

namespace Confab.Modules.Users.Domain.ValueObjects;

internal class UserRole : BaseValueObject
{
    public static IEnumerable<string> AvailableRoles { get; } = new[]
    {
        "User"
    };

    public string Value { get; }

    public UserRole(string value)
    {
        Value = value;
    }

    public static UserRole User => new UserRole("User");

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}