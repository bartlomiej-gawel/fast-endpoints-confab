namespace Confab.Shared.Exceptions.Policies;

public class PolicyException : Exception
{
    public IPolicy BrokenPolicy { get; }

    public string Details { get; }

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