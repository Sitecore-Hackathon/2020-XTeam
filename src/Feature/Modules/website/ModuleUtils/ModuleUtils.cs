using Sitecore;
using Sitecore.Data;
using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using xTeam.Feature.Modules.Module;
using static xTeam.Feature.Modules.ModuleUtils.ModuleUtilsConstant;

namespace xTeam.Feature.Modules.ModuleUtils
{
    public class ModuleUtils
    {
        public bool CreateModule(ModuleItem moduleItem) {

            Sitecore.Diagnostics.Assert.ArgumentNotNull(moduleItem, "Module Item");

            using (new Sitecore.SecurityModel.SecurityDisabler())
            {
                
                Sitecore.Data.Database master = Database.GetDatabase(ModuleUtilsConstant.MasterDatabase);
                Sitecore.Diagnostics.Assert.ArgumentNotNull(master, "Master Database");

                TemplateItem template = master.GetTemplate(IDs.TemplateId);
                Sitecore.Diagnostics.Assert.ArgumentNotNull(template, "Module Templete");

                Item parentItem = master.GetItem(IDs.ModuleFolderId);
                Sitecore.Diagnostics.Assert.ArgumentNotNull(parentItem, "Module Parent Folder");

                string itemName = Sitecore.Data.Items.ItemUtil.ProposeValidItemName($"{moduleItem.Title}-{moduleItem.Author}", "Module Item");

                using (new Sitecore.SecurityModel.SecurityDisabler())
                {
                    try
                    {
                        Item newItem = parentItem.Add(itemName, template);

                        if (newItem != null)
                        {
                            newItem.Editing.BeginEdit();

                            newItem.Fields[IDs.Fields.GitHubURL].Value = moduleItem.GitHubURL;
                            newItem.Fields[IDs.Fields.DocumentationURL].Value = moduleItem.DocumentationURL;
                            newItem.Fields[IDs.Fields.Title].Value = moduleItem.Title;
                            newItem.Fields[IDs.Fields.Summary].Value = moduleItem.Summary;
                            newItem.Fields[IDs.Fields.Author].Value = moduleItem.Author;
                            newItem.Fields[IDs.Fields.TestedAgainstSitecoreVersion].Value = moduleItem.TestedAgainstSitecoreVersion;
                            newItem.Fields[IDs.Fields.ProductLine].Value = moduleItem.ProductLine;

                            Sitecore.Data.Fields.DateField releaseDateField = newItem.Fields[IDs.Fields.ReleaseDate];
                            releaseDateField.Value = DateUtil.ToIsoDate(moduleItem.ReleaseDate);

                            Sitecore.Data.Fields.DateField lastCommitDateField = newItem.Fields[IDs.Fields.LastCommitDate];
                            lastCommitDateField.Value = DateUtil.ToIsoDate(moduleItem.LastCommitDate);
 
                            newItem.Fields[IDs.Fields.Stars].Value = moduleItem.Stars.ToString();
                            newItem.Fields[IDs.Fields.DownloadCount].Value = moduleItem.DownloadCount.ToString();
 

                            newItem.Editing.EndEdit();

                            PublishItem(newItem);
                            return true;
                        }

                    }
                    catch (System.Exception ex)
                    {
                        Sitecore.Diagnostics.Log.Error($"Could not create new item {itemName}", ex, this);
                        // newItem.Editing.CancelEdit();
                        
                    }
                }

                return false;

            }
        }


        private void PublishItem(Sitecore.Data.Items.Item item)
        {
            Sitecore.Publishing.PublishOptions publishOptions =  new Sitecore.Publishing.PublishOptions(item.Database, Database.GetDatabase(ModuleUtilsConstant.WebDatabase),
                                                     Sitecore.Publishing.PublishMode.SingleItem, item.Language,
                                                     System.DateTime.Now);  

            Sitecore.Publishing.Publisher publisher = new Sitecore.Publishing.Publisher(publishOptions);

            publisher.Options.RootItem = item;
            publisher.Options.Mode = Sitecore.Publishing.PublishMode.Full;

            publisher.Publish();
        }
    }
}