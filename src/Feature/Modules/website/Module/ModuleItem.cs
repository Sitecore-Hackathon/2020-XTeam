using Sitecore.ExperienceForms.Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace xTeam.Feature.Modules.Module
{
    public class ModuleItem
    {
        #region constructors
        // Used for building an empty item for deserialization
        public ModuleItem() { }

        // Used to build our item from form for serialization
        public ModuleItem(FormSubmitContext formSubmitContext)
        {
            buildItem(formSubmitContext);
        }
        #endregion

        #region Fields
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
        #endregion

        #region Methods

        /// <summary>
        /// Builds our item from form data 
        /// </summary>
        /// <param name="formSubmitContext"></param>
        private void buildItem(FormSubmitContext formSubmitContext)
        {
            // Process our form fields
            for(int i = 0; i < formSubmitContext.Fields.Count(); i++)
            {
                Sitecore.ExperienceForms.Models.IViewModel formField = formSubmitContext.Fields[i];
                var property = formField.GetType().GetProperty("Value");
                var propertyValue = property.GetValue(formField);
                var valueString = propertyValue.ToString();

                switch (formField.Name)
                {
                    case "GitHubURL":
                        GitHubURL = valueString;
                        break;
                    case "DocumentationURL":
                        DocumentationURL = valueString;
                        break;
                    case "Title":
                        Title = valueString;
                        break;
                    case "Summary":
                        Summary = valueString;
                        break;
                    case "Author":
                        Author = valueString;
                        break;
                    case "SupportedVersionsList":
                        TestedAgainstSitecoreVersion = valueString;
                        break;
                    case "ProductLine":
                        ProductLine = valueString;
                        break;
                }
            }

            // Now populate our other fields
            ReleaseDate = System.DateTime.Now;
            LastCommitDate = System.DateTime.Now;
            Stars = 0;
            DownloadCount = 0;
        }

        #endregion

    }
}