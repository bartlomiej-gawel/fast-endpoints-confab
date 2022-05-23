using Confab.Shared.Exceptions.CustomExceptions;

namespace Confab.Shared.Types;

public abstract class BaseEntity
{
    protected static void CheckPolicy(IPolicy policy)
    {
        if (policy.IsBroken())
        {
            throw new PolicyException(policy);
        }
    }
}