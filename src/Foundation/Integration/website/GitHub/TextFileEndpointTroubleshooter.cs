using Octokit;
using Sitecore.DataExchange.Models;
using Sitecore.DataExchange.Troubleshooters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xTeam.Foundation.Integration.GitHub;

namespace xTeam.Foundation.Integration.GitHub
{
    public class GitHubEndpointTroubleshooter : BaseEndpointTroubleshooter
    {
        public GitHubEndpointTroubleshooter()
        {
        }
        protected override ITroubleshooterResult Troubleshoot(Endpoint endpoint, TroubleshooterContext context)
        {
            var settings = endpoint.GetPlugin<GitHubSettings>();
            if (settings == null)
            {
                return TroubleshooterResult.FailResult("The endpoint is missing the plugin GitHubSettings.");
            }

            try
            {
                var apiInfo = settings.Client.GetLastApiInfo();

                if (apiInfo == null)
                {
                    return TroubleshooterResult.SuccessResult(Task.Run(() => GetRateInfo(settings.Client)).Result);
                }
                else {

                    return TroubleshooterResult.SuccessResult(GetLastRateInfo(apiInfo.RateLimit));
                }

            }
            catch (Exception ex) {
                return TroubleshooterResult.FailResult("API Error", ex);
            }

        }

        protected async Task<string> GetRateInfo(GitHubClient client)
        {
            var sb = new StringBuilder();

            var rateInfo = await client.Miscellaneous.GetRateLimits();
            var coreRateLimit = rateInfo.Resources.Core;
            sb.AppendLine("Connection Successful!").AppendLine();

            var howManyCoreRequestsCanIMakePerHour = coreRateLimit.Limit;
            sb.AppendLine($"Allowed {howManyCoreRequestsCanIMakePerHour} core requests per hour");

            var howManyCoreRequestsDoIHaveLeft = coreRateLimit.Remaining;
            var whenDoesTheCoreLimitReset = coreRateLimit.Reset; // UTC time
            sb.AppendLine($"{howManyCoreRequestsDoIHaveLeft} core requests left until {whenDoesTheCoreLimitReset.ToLocalTime()}");

            // the "search" object provides your rate limit status for the Search API.
            var searchRateLimit = rateInfo.Resources.Search;
            sb.AppendLine();
            var howManySearchRequestsCanIMakePerMinute = searchRateLimit.Limit;
            sb.AppendLine($"Allowed {howManySearchRequestsCanIMakePerMinute} search requests per minute");
            var howManySearchRequestsDoIHaveLeft = searchRateLimit.Remaining;
            var whenDoesTheSearchLimitReset = searchRateLimit.Reset; // UTC time
            sb.AppendLine($"{howManySearchRequestsDoIHaveLeft} core requests left until {whenDoesTheSearchLimitReset.ToLocalTime()}");

            return sb.ToString();
        }

        protected string GetLastRateInfo(RateLimit lastInfo)
        {
            var sb = new StringBuilder();

            sb.AppendLine("Connection Successful!").AppendLine();

            var howManyCoreRequestsCanIMakePerHour = lastInfo.Limit;
            sb.AppendLine($"Allowed {howManyCoreRequestsCanIMakePerHour} core requests per hour");

            var howManyCoreRequestsDoIHaveLeft = lastInfo.Remaining;
            var whenDoesTheCoreLimitReset = lastInfo.Reset; // UTC time
            sb.AppendLine($"{howManyCoreRequestsDoIHaveLeft} core requests left until {whenDoesTheCoreLimitReset.ToLocalTime()}");

            return sb.ToString();
        }
    }
}
