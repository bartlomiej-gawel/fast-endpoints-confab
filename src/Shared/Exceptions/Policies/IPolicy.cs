namespace Confab.Shared.Exceptions.Policies;

public interface IPolicy
{
    bool IsBroken();
    string Message { get; }
}