namespace Confab.Shared.Exceptions.CustomExceptions;

public interface IPolicy
{
    bool IsBroken();
    string? Message { get; }
}

public class PolicyException : Exception
{
    public IPolicy BrokenPolicy { get; }
    public string? Details { get; }

    public PolicyException(IPolicy brokenPolicy) : base(brokenPolicy.Message)
    {
        BrokenPolicy = brokenPolicy;
        Details = brokenPolicy.Message;
    }

    public override string ToString()
    {
        return $"{BrokenPolicy.GetType().FullName}: {BrokenPolicy.Message}";
    }
}