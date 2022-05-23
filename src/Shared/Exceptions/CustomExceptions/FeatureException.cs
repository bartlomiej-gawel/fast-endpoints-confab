namespace Confab.Shared.Exceptions;

public abstract class FeatureException : Exception
{
    protected FeatureException(string message) : base(message)
    {
    }
}