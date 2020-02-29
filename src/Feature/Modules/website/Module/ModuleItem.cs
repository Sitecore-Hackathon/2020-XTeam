using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace xTeam.Feature.Modules.Module
{
    public class ModuleItem
    {
        public string GitHubURL { get; set; }
        public string DocumentationURL { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Author { get; set; }
        public string TestedAgainstSitecoreVersion { get; set; }
        public string ProductLine { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime LastCommitDate { get; set; }
        public float Stars { get; set; }
        public int DownloadCount { get; set; }

    }
}