using Sitecore.DataExchange.Attributes;
using Sitecore.DataExchange.Converters.DataAccess.ValueAccessors;
using Sitecore.DataExchange.DataAccess;
using Sitecore.DataExchange.Repositories;
using Sitecore.Services.Core.Model;
using xTeam.Foundation.Integration.GitHub.Readers;

namespace xTeam.Foundation.Integration.GitHub.Accessors
{
    [SupportedIds(StarCountValueAccessorTemplateId)]
    public class GitHubStarCountAccessorConverter : ValueAccessorConverter
    {
        public const string StarCountValueAccessorTemplateId = "{97AD989B-522B-4E19-97FA-6AA209AFD15B}";

        public GitHubStarCountAccessorConverter(IItemModelRepository repository) : base(repository)
        {
        }

        protected override IValueReader GetValueReader(ItemModel source)
        {
            var valueReader = base.GetValueReader(source);
            if (valueReader == null)
            {
                valueReader = new GitHubStarCountReader();
            }
            return valueReader;
        }

    }
}
