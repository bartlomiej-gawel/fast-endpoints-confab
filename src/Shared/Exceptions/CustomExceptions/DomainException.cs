namespace Confab.Shared.Exceptions.CustomExceptions;

public class DomainException : Exception
{
    public DomainException(string message) : base(message)
    {
    }
}