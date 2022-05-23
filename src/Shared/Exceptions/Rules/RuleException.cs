namespace Confab.Shared.Exceptions.Rules;

public class RuleException : Exception
{
    public IRule BrokenRule { get; }

    public string Details { get; }

    public RuleException(IRule brokenRule) : base(brokenRule.Message)
    {
        BrokenRule = brokenRule;
        Details = brokenRule.Message;
    }

    public override string ToString()
    {
        return $"{BrokenRule.GetType().FullName}: {BrokenRule.Message}";
    }
}