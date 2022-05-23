using Confab.Shared.Exceptions;
using Confab.Shared.Types;
using Throw;

namespace Confab.Modules.Conferences.Domain.Conferences.ValueObjects;

internal class ConferenceDate : BaseValueObject
{
    public DateTime From { get; }
    public DateTime To { get; }

    public ConferenceDate(DateTime from, DateTime to)
    {
        from.Throw(_ => throw new DomainException("Conference start date cannot be yesterday or earlier."))
            .IfLessThan(DateTime.UtcNow);

        to.Throw(_ => throw new DomainException("Conference end date cannot be before start."))
            .IfEquals(from)
            .IfLessThan(from);

        From = from;
        To = to;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return From;
        yield return To;
    }
}