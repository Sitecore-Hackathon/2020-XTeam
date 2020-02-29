using Sitecore.DataExchange.Attributes;
using Sitecore.DataExchange.Converters.Endpoints;
using Sitecore.DataExchange.Models;
using Sitecore.DataExchange.Repositories;
using Sitecore.Services.Core.Model;

namespace xTeam.Foundation.Integration.GitHub
{
    [SupportedIds(EndpointTemplateId)]
    public class GitHubEndpointConverter : BaseEndpointConverter
    {
        public const string EndpointTemplateId = "{C1938C4F-0FBC-490B-9A34-E000C512AD89}";
        public const string AppName = "sc-community-marketplace";

        public GitHubEndpointConverter(IItemModelRepository repository) : base(repository)
        {
        }
        protected override void AddPlugins(ItemModel source, Endpoint endpoint)
        {
            //
            //create the plugin
            var settings = new GitHubSettings();

            //
            //add the plugin to the endpoint
            endpoint.AddPlugin(settings);
        }
    }
}
