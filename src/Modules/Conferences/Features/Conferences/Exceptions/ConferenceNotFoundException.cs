using Confab.Shared.Exceptions.CustomExceptions;

namespace Confab.Modules.Conferences.Features.Conferences.Exceptions;

internal class ConferenceNotFoundException : FeatureException
{
    public Guid ConferenceId { get; }
    
    public ConferenceNotFoundException(Guid conferenceId) : base($"Conference with ID: '{conferenceId}' was not found.")
    {
        ConferenceId = conferenceId;
    }
}