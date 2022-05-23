using Confab.Shared.Exceptions.Rules;

namespace Confab.Shared.Types;

public abstract class BaseEntity
{
    protected static void CheckRule(IRule rule)
    {
        if (rule.IsBroken())
        {
            throw new RuleException(rule);
        }
    }
}