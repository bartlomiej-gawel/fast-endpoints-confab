using System.Runtime.Serialization;

namespace Confab.Modules.Users.Domain.ValueObjects;

internal enum UserStatus
{
    [EnumMember(Value = "Active")] Active = 1,
    [EnumMember(Value = "Inactive")] Inactive = 2
}