using Sitecore.DataExchange.Attributes;
using Sitecore.DataExchange.Converters.DataAccess.ValueAccessors;
using Sitecore.DataExchange.DataAccess;
using Sitecore.DataExchange.DataAccess.Readers;
using Sitecore.DataExchange.DataAccess.Writers;
using Sitecore.DataExchange.Repositories;
using Sitecore.Services.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xTeam.Foundation.Integration.GitHub.Readers;

namespace xTeam.Foundation.Integration.GitHub.Accessors
{
    [SupportedIds(ValueAccessorTemplateId)]
    public class GitHubReadMeAccessorConverter : ValueAccessorConverter
    {
        public const string ValueAccessorTemplateId = "{0ABC5213-530C-408E-896B-8A9B80FE62B1}";

        public GitHubReadMeAccessorConverter(IItemModelRepository repository) : base(repository)
        {
        }

        protected override IValueReader GetValueReader(ItemModel source)
        {
            var valueReader = base.GetValueReader(source);
            if (valueReader == null)
            {
                valueReader = new GitHubReadMeReader();
            }
            return valueReader;
        }
    }
}
