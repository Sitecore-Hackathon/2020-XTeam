using Octokit;
using Sitecore.DataExchange.DataAccess;
using System;
using System.Threading.Tasks;

namespace xTeam.Foundation.Integration.GitHub.Readers
{
    public abstract class AbstractGitHubReader : IValueReader
    {
        public virtual ReadResult Read(object source, DataAccessContext context)
        {
            var repoModel = source as RepoModel;
            if (repoModel == null)
            {
                return ReadResult.NegativeResult(DateTime.Now);
            }
            var client = new GitHubClient(new ProductHeaderValue(GitHubEndpointConverter.AppName));
            var value = Task.Run(() => GetGitHubValue(client, repoModel)).Result;
            return ReadResult.PositiveResult(value, DateTime.Now);
        }


        public abstract Task<string> GetGitHubValue(GitHubClient client, RepoModel repo);
    }
}