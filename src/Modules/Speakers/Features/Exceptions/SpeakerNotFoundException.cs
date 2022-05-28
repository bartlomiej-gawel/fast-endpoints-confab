using Confab.Shared.Exceptions.CustomExceptions;

namespace Confab.Modules.Speakers.Features.Exceptions;

public class SpeakerNotFoundException : FeatureException
{
    public Guid Id { get; }
    
    public SpeakerNotFoundException(Guid id) : base($"Speaker with id '{id}' was not found.")
    {
        Id = id;
    }
}