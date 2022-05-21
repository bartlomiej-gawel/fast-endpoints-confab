using Confab.Shared.Exceptions;

namespace Confab.Modules.Conferences.Features.Hosts.Exceptions;

internal class HostNotFoundException : AppException
{
    public Guid HostId { get; }
    
    public HostNotFoundException(Guid hostId) : base($"Host with ID: '{hostId}' was not found.")
    {
        HostId = hostId;
    }
}