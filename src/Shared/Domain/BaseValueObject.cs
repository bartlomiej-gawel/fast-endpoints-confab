using Confab.Shared.Exceptions.CustomExceptions;

namespace Confab.Shared.Domain;

public abstract class BaseValueObject
{
    protected abstract IEnumerable<object> GetEqualityComponents();

    public override bool Equals(object obj)
    {
        if (obj == null)
        {
            return false;
        }

        if (GetType() != obj.GetType())
        {
            return false;
        }

        var valueObject = (BaseValueObject)obj;

        return GetEqualityComponents().SequenceEqual(valueObject.GetEqualityComponents());
    }

    public override int GetHashCode()
    {
        return GetEqualityComponents().Aggregate(1, (current, obj) =>
        {
            unchecked
            {
                return current * 23 + (obj?.GetHashCode() ?? 0);
            }
        });
    }

    public static bool operator ==(BaseValueObject a, BaseValueObject b)
    {
        if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
        {
            return true;
        }

        if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
        {
            return false;
        }

        return a.Equals(b);
    }

    public static bool operator !=(BaseValueObject a, BaseValueObject b)
    {
        return !(a == b);
    }
    
    protected static void CheckPolicy(IPolicy policy)
    {
        if (policy.IsBroken())
        {
            throw new PolicyException(policy);
        }
    }
}