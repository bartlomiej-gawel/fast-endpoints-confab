namespace Confab.Shared.Exceptions.CustomExceptions;

public abstract class FeatureException : Exception
{
    protected FeatureException(string message) : base(message)
    {
    }
}