using Confab.Modules.Conferences.Domain.Conferences;
using Confab.Shared.Exceptions.Policies;

namespace Confab.Modules.Conferences.Domain.Hosts.Policies;

internal class HostDeletionPolicy : IPolicy
{
    private readonly List<Conference> _conferences;
    
    public HostDeletionPolicy(List<Conference> conferences)
    {
        _conferences = conferences;
    }

    public bool IsBroken()
    {
        if (!_conferences.Any())
        {
            return false;
        }

        foreach (var conference in _conferences)
        {
            conference.Delete();
        }

        return true;
    }

    public string Message => "Host conferences are not empty";
}