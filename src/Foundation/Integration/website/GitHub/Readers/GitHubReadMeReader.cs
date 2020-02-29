using Octokit;
using System.Threading.Tasks;

namespace xTeam.Foundation.Integration.GitHub.Readers
{
    public class GitHubReadMeReader : AbstractGitHubReader
    {
        public async override Task<string> GetGitHubValue(GitHubClient client, RepoModel repo)
        {
            return await client.Repository.Content.GetReadmeHtml(repo.Owner, repo.Name);
        }
    }
}