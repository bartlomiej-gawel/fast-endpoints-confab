using Confab.Modules.Conferences.Domain.Conferences.ValueObjects;
using Confab.Shared.Exceptions.Policies;

namespace Confab.Modules.Conferences.Domain.Conferences.Policies;

public class ConferenceDeletionPolicy : IPolicy
{
    private readonly ConferenceDate _date;

    public ConferenceDeletionPolicy(ConferenceDate date)
    {
        _date = date;
    }
    
    public bool IsBroken()
    {
        return DateTime.UtcNow.Date.AddDays(7) < _date.Value.From;
    }

    public string Message => "Cannot delete conference because it will be start in 7 days";
}