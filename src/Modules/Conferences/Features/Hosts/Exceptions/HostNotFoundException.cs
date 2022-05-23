using Confab.Shared.Exceptions;
using Confab.Shared.Exceptions.CustomExceptions;

namespace Confab.Modules.Conferences.Features.Hosts.Exceptions;

internal class HostNotFoundException : FeatureException
{
    public Guid HostId { get; }
    
    public HostNotFoundException(Guid hostId) : base($"Host with ID: '{hostId}' was not found.")
    {
        HostId = hostId;
    }
}