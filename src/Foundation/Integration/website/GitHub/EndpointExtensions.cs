using Sitecore.DataExchange.Models;

namespace xTeam.Foundation.Integration.GitHub
{
    public static class EndpointExtensions
    {
        public static GitHubSettings GetGitHubSettings(this Endpoint endpoint)
        {
            return endpoint.GetPlugin<GitHubSettings>();
        }
        public static bool HasGitHubSettings(this Endpoint endpoint)
        {
            return (GetGitHubSettings(endpoint) != null);
        }
    }
}
