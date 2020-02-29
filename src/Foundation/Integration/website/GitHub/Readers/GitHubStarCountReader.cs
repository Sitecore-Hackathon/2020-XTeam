using Octokit;
using System.Threading.Tasks;

namespace xTeam.Foundation.Integration.GitHub.Readers
{
    public class GitHubStarCountReader : AbstractGitHubReader
    {
        public async override Task<string> GetGitHubValue(GitHubClient client, RepoModel repo)
        {
            var stats = await client.Activity.Starring.GetAllStargazers(repo.Owner, repo.Name);
            // var trafficRequest = new RepositoryTrafficRequest(TrafficDayOrWeek.Week);
            // await client.Repository.Traffic.GetViews(repo.Owner, repo.Name, trafficRequest);
            return (stats?.Count ?? 0).ToString();
        }
    }
}