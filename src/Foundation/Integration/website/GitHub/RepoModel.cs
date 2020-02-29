using System;
using System.Linq;

namespace xTeam.Foundation.Integration.GitHub
{
    [Serializable]
    public class RepoModel // : FieldDictionary
    {
        public string Owner { get; set; }
        public string Name { get; set; }


        public RepoModel(object gitUrl)
        {
            ParseProps(gitUrl as string);
        }

        protected void ParseProps(string gitUrl)
        {
            if (string.IsNullOrWhiteSpace(gitUrl))
                return;

            var segments = gitUrl.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            if (!segments.Any())
                return;

            for (var i = 0; i < segments.Length; i++) {
                var segment = segments[i];
                if (segment.Equals("github.com", StringComparison.OrdinalIgnoreCase)) {
                    var ownerIndex = i + 1;
                    if(ownerIndex < segments.Length)
                    {
                        this.Owner = segments[ownerIndex];
                    }
                    var nameIndex = i + 2;
                    if (nameIndex < segments.Length)
                    {
                        this.Name = segments[nameIndex];
                    }
                    break;
                }
            }
        }
        //protected RepoModel(SerializationInfo info, StreamingContext context) : base(info, context)
        //{
        //}
    }

}