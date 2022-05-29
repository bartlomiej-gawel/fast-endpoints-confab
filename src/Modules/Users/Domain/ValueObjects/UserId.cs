using Confab.Shared.Domain;

namespace Confab.Modules.Users.Domain.ValueObjects;

internal class UserId : BaseId
{
    public UserId(Guid value) : base(value)
    {
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}