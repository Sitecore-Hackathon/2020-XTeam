using Octokit;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace xTeam.Foundation.Integration.GitHub.Readers
{
    public class GitHubLastCommitDateReader : AbstractGitHubReader
    {
        public async override Task<string> GetGitHubValue(GitHubClient client, RepoModel repo)
        {
            // var apiOptions = new ApiOptions();
            //var stats = await client.Repository.Commit.GetAll(repo.Owner, repo.Name);
            //return stats.LastOrDefault()?.
            return DateTime.MinValue.ToString();
        }
    }
}