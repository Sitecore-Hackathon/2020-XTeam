using Octokit;
using Sitecore.DataExchange;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xTeam.Foundation.Integration.GitHub
{
    public class GitHubSettings : IPlugin
    {
        public GitHubSettings() { }
        public GitHubClient Client { get; set; }
    }
}
