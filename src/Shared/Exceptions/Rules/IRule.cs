namespace Confab.Shared.Exceptions.Rules;

public interface IRule
{
    bool IsBroken();

    string Message { get; }
}