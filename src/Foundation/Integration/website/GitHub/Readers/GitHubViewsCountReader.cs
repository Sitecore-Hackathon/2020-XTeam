using Octokit;
using System.Threading.Tasks;

namespace xTeam.Foundation.Integration.GitHub.Readers
{
    public class GitHubViewsCountReader : AbstractGitHubReader
    {
        public async override Task<string> GetGitHubValue(GitHubClient client, RepoModel repo)
        {
            var trafficRequest = new RepositoryTrafficRequest(TrafficDayOrWeek.Week);
            // var stats = await client.Repository.Traffic.GetClones(repo.Owner, repo.Name, trafficRequest);
            var stats = await client.Repository.Traffic.GetViews(repo.Owner, repo.Name, trafficRequest);
            return (stats?.Uniques ?? 0).ToString();
        }
    }
}