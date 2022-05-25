using Confab.Shared.Exceptions.CustomExceptions;
using Confab.Shared.Types;
using Throw;

namespace Confab.Modules.Conferences.Domain.Conferences.ValueObjects;

internal class ConferenceLocation : BaseValueObject
{
    public string City { get; }
    public string Street { get; }

    public ConferenceLocation(string city, string street)
    {
        city.Throw(_ => throw new DomainException("Please specify a correct location city. 3-50 characters."))
            .IfShorterThan(3)
            .IfLongerThan(50);

        street.Throw(_ => throw new DomainException("Please specify a correct location street. 3-50 characters."))
            .IfShorterThan(3)
            .IfLongerThan(50);

        City = city;
        Street = street;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return City;
        yield return Street;
    }
}