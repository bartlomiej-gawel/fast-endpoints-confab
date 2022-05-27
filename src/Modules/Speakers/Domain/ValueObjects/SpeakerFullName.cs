using Confab.Shared.Domain;
using Confab.Shared.Exceptions.CustomExceptions;
using Throw;

namespace Confab.Modules.Speakers.Domain.ValueObjects;

internal class SpeakerFullName : BaseValueObject
{
    public string FirstName { get; }
    public string LastName { get; }

    public SpeakerFullName(string firstName, string lastName)
    {
        firstName.Throw(_ => throw new DomainException("Please specify a correct speaker first name. 2-30 characters."))
            .IfShorterThan(2)
            .IfLongerThan(30);

        lastName.Throw(_ => throw new DomainException("Please specify a correct speaker last name. 2-30 characters."))
            .IfShorterThan(2)
            .IfLongerThan(30);
        
        FirstName = firstName;
        LastName = lastName;
    }

    public string GetFullName => FirstName + " " + LastName;

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return FirstName;
        yield return LastName;
    }
}