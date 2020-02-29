using Sitecore.DataExchange.Attributes;
using Sitecore.DataExchange.Converters.DataAccess.ValueAccessors;
using Sitecore.DataExchange.DataAccess;
using Sitecore.DataExchange.Repositories;
using Sitecore.Services.Core.Model;
using xTeam.Foundation.Integration.GitHub.Readers;

namespace xTeam.Foundation.Integration.GitHub.Accessors
{
    [SupportedIds(TrendingValueAccessorTemplateId)]
    public class GitHubTrendingViewsAccessorConverter : ValueAccessorConverter
    {
        public const string TrendingValueAccessorTemplateId = "{DA01EBC9-65EF-4D6A-BBE4-E1B588610B40}";

        public GitHubTrendingViewsAccessorConverter(IItemModelRepository repository) : base(repository)
        {
        }

        protected override IValueReader GetValueReader(ItemModel source)
        {
            var valueReader = base.GetValueReader(source);
            if (valueReader == null)
            {
                valueReader = new GitHubViewsCountReader();
            }
            return valueReader;
        }

    }
}
