using Confab.Modules.Conferences.Domain.Conferences.ValueObjects;
using Confab.Shared.Exceptions.CustomExceptions;

namespace Confab.Modules.Conferences.Domain.Conferences.Policies;

internal class ConferenceDeletionPolicy : IPolicy
{
    private readonly ConferenceDate _date;
    private readonly ConferenceParticipantsLimit _participantsLimit;

    public ConferenceDeletionPolicy(
        ConferenceDate date,
        ConferenceParticipantsLimit participantsLimit)
    {
        _date = date;
        _participantsLimit = participantsLimit;
    }

    public bool IsBroken()
    {
        if (_participantsLimit.Value > 0)
        {
            Message = "Cannot delete conference because participants already registered";
            
            return true;
        }

        if (DateTime.UtcNow.Date.AddDays(7) < _date.From.Date)
        {
            Message = "Cannot delete conference because it will be start in 7 days";

            return true;
        }

        return false;
    }

    public string? Message { get; private set; }
}