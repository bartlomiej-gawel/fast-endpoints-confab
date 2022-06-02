using Confab.Modules.Users.Domain.ValueObjects;
using Confab.Shared.Domain;

namespace Confab.Modules.Users.Domain;

internal class User : BaseEntity
{
    public UserId Id { get; private set; }
    public UserEmail Email { get; private set; }
    public UserPassword Password { get; private set; }
    public UserRole Role { get; private set; }
    public UserStatus Status { get; private set; }
    public DateTime CreatedAt { get; private set; }

    private User()
    {
    }

    private User(UserEmail email, UserPassword password)
    {
        Id = new UserId(Guid.NewGuid());
        Email = email;
        Password = password;
        Role = UserRole.User;
        Status = UserStatus.Active;
        CreatedAt = DateTime.UtcNow;
    }

    public static User Create(UserEmail email, UserPassword password)
    {
        return new User(email, password);
    }
}