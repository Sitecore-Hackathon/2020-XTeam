using Sitecore.Services.Core.Model;
using System;
using System.Runtime.Serialization;

namespace xTeam.Foundation.Integration.GitHub
{
    [Serializable]
    public class RepoModel : FieldDictionary
    {
        public const string Owner = "Owner";

        public const string Name = "Name";

        public RepoModel()
        {
        }

        protected RepoModel(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

}