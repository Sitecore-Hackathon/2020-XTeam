using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace xTeam.Foundation.Integration.GitHub
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var readme = Task.Run(() => GetReadMe("DigitalParkour", "Community.Foundation.DesignBot")).Result;
            var asdf = readme.Content;

        }

        protected async Task<Readme> GetReadMe(string owner, string name) {

            var client = new GitHubClient(new ProductHeaderValue("sc-community-marketplace"));
            var readme = await client.Repository.Content.GetReadme(owner, name);
            return readme;
        }
    }
}