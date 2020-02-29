using Sitecore.DataExchange.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
