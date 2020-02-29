using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;

namespace xTeam.Feature.Modules.ModuleUtils
{
    public class ModuleUtilsConstant
    {
        public struct IDs
        {
            public readonly static ID ModuleFolderId = new ID("{159F1FA5-54AB-4FDC-876F-E0C427E0A98D}");
            public readonly static ID TemplateId = new ID("{51E67DFC-CCA5-4283-9157-50D310732F11}");

            public struct Fields {
                public readonly static ID GitHubURL  = new ID("{345D5BB4-A027-4A69-AC4F-A145E05474E2}");
                public readonly static ID DocumentationURL = new ID("{4D64CE38-4DDA-4072-A4F1-A781D09BABD9}");
                public readonly static ID Title = new ID("{73A766C5-576A-49C3-BA97-43C5C75CB759}");
                public readonly static ID Summary = new ID("{D3741A17-C75F-49B0-80E9-DCBFBD2593F0}");
                public readonly static ID Author = new ID("{96375F05-4682-479B-9512-4D97C3611F16}");
                public readonly static ID TestedAgainstSitecoreVersion = new ID("{A6EC2225-F000-46A3-8FD0-A3D4812037F9}");
                public readonly static ID ProductLine = new ID("{94D22B54-63C5-49B8-AD51-A214B7805418}");
                public readonly static ID ReleaseDate = new ID("{0A02003C-9C46-416D-8A28-5EDAAC8AE49C}");
                public readonly static ID LastCommitDate = new ID("{B4633D93-7E3A-4D08-8B44-852CC925FD19}");
                public readonly static ID Stars = new ID("{61B1CB45-6894-4931-8138-7D37864C4EAF}");
                public readonly static ID DownloadCount = new ID("{29FFCF6A-3300-4EEF-BD80-59AA99404D18}");
            }
        }
        public const string MasterDatabase = "Master";
        public const string WebDatabase = "Web";
}
}