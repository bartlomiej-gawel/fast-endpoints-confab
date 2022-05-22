using Confab.Shared.Exceptions;

namespace Confab.Modules.Conferences.Features.Conferences.Exceptions;

internal class ConferenceNotFoundException : AppException
{
    public Guid ConferenceId { get; }
    
    public ConferenceNotFoundException(Guid conferenceId) : base($"Conference with ID: '{conferenceId}' was not found.")
    {
        ConferenceId = conferenceId;
    }
}